// rozwijanie meczy drużyny
$("tr.team-info").click(function (e) {
    if (!$(e.target).hasClass("favorite-icon")) {
        $(this).next("tr").toggle(300);
    }
});

// dodawanie do ulubionych
$(".favorite-icon").one("click", AddOrRemoveFavoriteTeam);

function AddOrRemoveFavoriteTeam() {

    const $this = $(this);
    const isFavorite = $this.hasClass("favorite-team");
    const teamId = $this.attr("id");

    $this.toggleClass("favorite-team");

    if (isFavorite) {
        $this.attr("title", "Dodaj do ulubionych")
    }
    else {
        $this.attr("title", "Usuń z ulubionych")
    }

    $.ajax({
        url: "/Home/AddOrRemoveFavoriteTeam",
        method: "POST",
        data: { teamId: teamId, isFavorite: isFavorite },
        success: () => $this.one("click", AddOrRemoveFavoriteTeam),
        error: () => showAjaxError()
    });
}
