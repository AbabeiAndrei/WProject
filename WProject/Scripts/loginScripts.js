var loginClicked = false;
var ExecuteLogin;
var functionSetRotationCircleDash = function (start) {
    loginClicked = start;
    if (start) {
        
        $("#circleLogin").attr("src", "Resources/Icons/circle_dash.png");
        $("#circleLogin").addClass("rotateAndOpacityAnimationClass");
        $("#arrowLogin").addClass("opacityAnimationClass");
    }
    else {
        $("#circleLogin").attr("src", "Resources/Icons/circle.png");
        $("#circleLogin").removeClass("rotateAndOpacityAnimationClass");
        $("#arrowLogin").removeClass("opacityAnimationClass");
    }
}

$(document).ready(function () {
    var mlohin = function () {
        if (loginClicked)
            return;
        $("#arrowLogin").removeClass("loginLoginControlTransparent")
                        .addClass("loginLoginControlOpaque")
                        .addClass("leftToRightAnimationClass");
        $("#circleLogin").removeClass("loginLoginControlTransparent")
                         .addClass("loginLoginControlOpaque");

    }
    var mlohout = function () {
        if (loginClicked)
            return;
        $("#arrowLogin").removeClass("loginLoginControlOpaque")
                        .removeClass("leftToRightAnimationClass")
                        .addClass("loginLoginControlTransparent");

        $("#circleLogin").removeClass("loginLoginControlOpaque")
                         .addClass("loginLoginControlTransparent");

    }

    $("#loginContainerButton").hover(mlohin, mlohout);
    $("#loginContainerButton").click(function () {

        functionSetRotationCircleDash(true);

        ExecuteLogin();
    });
})