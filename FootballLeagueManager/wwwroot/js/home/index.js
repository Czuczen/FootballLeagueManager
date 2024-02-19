// dopasowanie rozmiarów karty ligi do backside
$('.feature.col-xs-12.col-md-3.col-sm-6').each(function () {
    const $this = $(this);
    const backsideHeight = $this.find('.backside').outerHeight();
    const backsideListHeight = $this.find('.list-inline').outerHeight();

    const height = parseInt(backsideHeight) + parseInt(backsideListHeight);
    const thisHeight = $this.css('height');

    if (height > parseInt(thisHeight)) {
        $this.css('height', height + 'px');
    }
});

$("a.feature").click(function () {
    const $this = $(this);
    const leagueId = $this.attr("id").substring($this.attr("id").indexOf("-") + 1);
    const seasonId = $("#season-" + leagueId).val();
    
    window.location.href = window.location.pathname + "Home/LeagueTable?seasonId=" + seasonId;
});
