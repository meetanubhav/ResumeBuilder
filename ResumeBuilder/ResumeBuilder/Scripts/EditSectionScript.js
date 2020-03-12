function EditSectionScripts() {
    $('.js-show-summary, .js-show-education , .hide, .js-show-language , .js-show-skills , .js-show-projects , .js-show-workexp').hide();

    $('.js-toggle').hide();
    
    //$('.home-dash').toggle();
    $('.show-edit-section').show();

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
        if ($(this).attr('value') === "percentage") {
            $('input[name = "gradetype"]').attr('placeholder', "Percentage");
        }
        else {
            $('input[name = "gradetype"]').attr('placeholder', "CGPA");
        }
    });
    
    //Data Fill Contents by Bhabani "/EditResume/BasicInfo"
    $('.save-basic-info').on("click", function () {

        var formData = $('.basic-info-form').serialize();
        
    });

    $('.btn-save').on("click", function () {

        var formData = $(this).parent().serialize();
        
    });
}
