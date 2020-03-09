$(document).ready(function () {
    $('.js-show-summary .js-show-education .js-show-language .js-show-skills .js-show-projects .js-show-workexp').hide();
    for (i = 0; i <= 50; i++) {
        $('.project-duration').append($('<option></option>').val(i).html(i))
    }

    $('.summary').on("click", function (e) {
        e.preventDefault();
        $('.js-show-summary').toggle(300);
    });

    $('.education').on("click", function (e) {
        e.preventDefault();
        $('.js-show-education').toggle(300);
    });

    $('.language').on("click", function (e) {
        e.preventDefault();
        $('.js-show-language').toggle(300);
    });

    $('.skills').on("click", function (e) {
        e.preventDefault();
        $('.js-show-skills').toggle(300);
    });

    $('.projects').on("click", function (e) {
        e.preventDefault();
        $('.js-show-projects').toggle(300);
    });
    
    $('input[name = "educationLevel"]').on("click", function () {
        if ($(this).attr('value') == "secondary" || $(this).attr('value') == "seniorSecondary") {
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