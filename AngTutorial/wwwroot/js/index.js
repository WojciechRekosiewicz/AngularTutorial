$(document).ready(function() {

    console.log("kappa");

    var theForm = $("#theForm");

    theForm.hide();

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("Buying Item");
    });


    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You clicked on " + $(this).text());
    });

    var $logginToggle = $("#logginToggle");
    var $popupForm = $(".popup-form");

    $logginToggle.on("click", function () {
        $popupForm.fadeToggle(100);
    });










});