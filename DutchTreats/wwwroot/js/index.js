$(document).ready(function () {

    var x = 3.14;
    var y = "hello world";

    console.log(x);
    console.log(y);

    var theForm = $("#theForm");
    var theButton = $("#buyButton");

    theButton.on("click", () => { console.log("buy button pressed") });
    theForm.hide();

    var productInfo = $(".products-props li");
    var listItems = productInfo.on("click", function () {
        console.log("you clicked on " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-Form")

    $loginToggle.on("click", function () {
        $popupForm.toggle();
    });

});
