﻿$(document).ready(function () {
    //$('.js-show-summary, .js-show-education , .js-show-language , .js-show-skills , .js-show-projects , .js-show-workexp').hide();
﻿
    //function EditSectionScripts() {
        $('.js-toggle').hide();
        for (i = 0; i <= 50; i++) {
            $('.project-duration').append($('<option></option>').val(i).html(i))
        }
        $('.js-edit').on("click", function () {
            $('.home-dash').toggle();
            $('.show-edit-section').toggle();
            return false;
        });
        $('.js-click').on('click', function () {
            console.log(1);
            $(this).next().toggle(300);
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
    //}
});