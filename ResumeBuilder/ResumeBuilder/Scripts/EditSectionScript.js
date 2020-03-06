$(document).ready(function () {
    $('.js-show-summary .js-show-education .js-show-language .js-show-skills').hide();

    $('.summary').on("click", function (e) {
        e.preventDefault();
        $('.js-show-summary').toggle(300);
    });

    $('.education').on("click", function (e) {
        e.preventDefault();
        $('.js-show-education').toggle(300);
    });

    $('input[name = "optradio"]').on("click", function () {
        if ($(this).attr('value') == "10th" || $(this).attr('value') == "12th") {
            $('input[name = "stream"]').hide();
            $('input[name = "university"]').hide();
        }
        else {
            $('input[name = "stream"]').show();
            $('input[name = "university"]').show();
        }
    });
    $('input[name = "optradio"]').on("click", function () {
        if ($(this).attr('value') == "percentage") {
            $('input[name = "gradetype"]').attr('placeholder', "Percentage");
        }
        else {
            $('input[name = "gradetype"]').attr('placeholder', "CGPA");
        }
    });
});