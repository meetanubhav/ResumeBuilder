function EditSectionScripts() {
    $('.js-show-summary, .js-show-education , .hide, .js-show-language , .js-show-skills , .js-show-projects , .js-show-workexp').hide();

    $('.js-toggle').hide();
    $('.js-edit').on("click", function () {
        $('.home-dash').toggle();
        $('.show-edit-section').toggle();
        return false;
    });
    $('.js-click').on('click', function () {
        console.log(1);
        $(this).next().toggle(300);
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

    $('.save-summary').on("click", function () {
        var formData = $('.summary-form').serialize();        $.ajax({
            url: "/ActionName",            data: formData,            success: function (data) {
                alert(data);
            }
        });        $(this).parent().parent().next().next().show(300);
    });    //
}
