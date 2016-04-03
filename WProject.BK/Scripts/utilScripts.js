var showNotificationBar = function(message, duration, bgColor, txtColor, height) {

    /*set default values*/
    duration = typeof duration !== 'undefined' ? duration : 1500;
    bgColor = typeof bgColor !== 'undefined' ? bgColor : "#ef5350";
    txtColor = typeof txtColor !== 'undefined' ? txtColor : "white";
    height = typeof height !== 'undefined' ? height : 40;
    /*create the notification bar div if it doesn't exist*/
    if ($('#notification-bar').size() == 0) {
        var HTMLmessage = "<div class='notification-message' style='text-align:center; line-height: " +
            height + "px;'> " + message + " </div>";
        $('body').prepend("<script>$('#notification-bar').click(function(){$('#notification-bar').slideUp(function () { });});</script>" +
            "<div id='notification-bar' style='display:none; width:100%; cursor:pointer;height:" + height + "px; " +
            "background-color: " + bgColor + "; position: fixed; z-index: 100; " +
            "font-family:'Segoe UI'; font-weight:100;font-size:15px; " +
            "color: " + txtColor + ";border-bottom: 1px solid black;'>" + HTMLmessage + "</div>");
    }
    /*animate the bar*/
    $('#notification-bar').slideDown(function() {
        setTimeout(function() {
            $('#notification-bar').slideUp(function() {});
        }, duration);
    });
};
var defaultTimeOutNotificationBar = 10000;

function sendAjax(url, fn, data, onsuccess, onerror) {
    $.ajax({
        type: "POST",
        url: url + "/" + fn,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onsuccess,
        failure: onerror 
    });
}