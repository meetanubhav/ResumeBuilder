function EditSectionScripts() {
    $('.show-edit-section').show();

    for (var i = 1; i <= 12; i++) {
        $('.project-duration').append('<option>'+i+'</option>');
    }

    $('input[name = "educationLevel"]').on("click", function() {
        if ($(this).attr('value') == "secondary" || $(this).attr('value') == "seniorSecondary") {
            $('input[name = "stream"]').hide();
            $('input[name = "university"]').hide();
        } else {
            $('input[name = "stream"]').show();
            $('input[name = "university"]').show();
        }
    });
    $('input[name = "optradio"]').on("click", function() {
        if ($(this).attr('value') === "percentage") {
            $('input[name = "gradetype"]').attr('placeholder', "Percentage");
        } else {
            $('input[name = "gradetype"]').attr('placeholder', "CGPA");
        }
    });
}