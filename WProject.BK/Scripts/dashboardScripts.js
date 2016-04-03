$(document).ready(function() {
    $("#springCollapseIcon").click(function() {
        $(".springs").css("display", "none");
        $("#springsSeparator").css("display", "none");
        $("#springsCollapsedSeparator").css("display", "block");
    });

    $("#springExpandIcon").click(function () {
        $(".springs").css("display", "block");
        $("#springsSeparator").css("display", "block");
        $("#springsCollapsedSeparator").css("display", "none");
    });
})