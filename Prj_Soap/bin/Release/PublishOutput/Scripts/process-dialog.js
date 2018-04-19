function getProcessDialog() {
    $body = $("body");
    $("html").css("overflow", "hidden");
    $body.addClass("loading");
}

function disableProcessDialog(time) {
    setTimeout(
        function () {
            $body = $("body");
            $("html").css("overflow", "");
            $body.removeClass("loading");
        }, time);
    
}