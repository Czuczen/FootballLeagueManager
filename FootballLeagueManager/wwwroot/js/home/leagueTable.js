// rozwijanie meczy drużyny
$("tr.team-info").click(function (e) {
    if (!$(e.target).hasClass("favorite-icon")) {
        $(this).next("tr").toggle(300);
    }
});

// dodawanie do ulubionych
$(".favorite-icon").one("click", AddOrRemoveFavoriteTeam);

function AddOrRemoveFavoriteTeam () {

    const $this = $(this);
    const isFavorite = $this.hasClass("favorite-team");
    const teamId = $this.attr("id");

    $this.toggleClass("favorite-team");

    $.ajax({
        url: "/Home/AddOrRemoveFavoriteTeam",
        method: "POST",
        data: { teamId: teamId, isFavorite: isFavorite },
        success: data => {
            console.log(data);
            $this.one("click", AddOrRemoveFavoriteTeam);
        },
        error: () => showAjaxError()
    });
}
