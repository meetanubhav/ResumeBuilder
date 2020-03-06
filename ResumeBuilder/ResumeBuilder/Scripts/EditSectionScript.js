$(document).ready(function () {
    $('.js-show-summary .js-show-education').hide();

    $('.summary').on("click", function (e) {
        e.preventDefault();
        $('.js-show-summary').toggle(300);
    });

    $('.education').on("click", function (e) {
        e.preventDefault();
        $('.js-show-education').toggle(300);
    });
});