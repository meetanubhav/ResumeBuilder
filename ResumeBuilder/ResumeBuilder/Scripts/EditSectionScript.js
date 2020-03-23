function EditSectionScripts() {
    $('.show-edit-section').show();
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
    $('body').on('click','.js-delete-education', function () {
       $(this).parent().parent().remove();
    });
}
