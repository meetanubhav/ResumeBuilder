function EditSectionScripts() {
    //$('.show-edit-section').show();
    //$('body').on("click",'input[name = "educationLevel"]', function () {
    //    if ($(this).attr('value') == "secondary" || $(this).attr('value') == "seniorSecondary") {
    //        $('input[name = "stream"]').hide();
    //        $('input[name = "university"]').hide();
    //    }
    //    else {
    //        $('input[name = "stream"]').show();
    //        $('input[name = "university"]').show();
    //    }
    //});
    $('body').on("click", 'input[name = "optradio"]', function () {
        if ($(this).attr('value') == "percentage") {
            $('input[name = "gradetype"]').attr('placeholder', "Percentage");
        }
        else {
            $('input[name = "gradetype"]').attr('placeholder', "CGPA");
        }
    });
    $("body").on("click", "#currentWork", function () {
        if (this.checked == true) {
            $("#ToYear").hide();
            $("#ToYear").val('Current');
        } else {
            $("#toYear").show();
            $("#toYear").val('');
        }

    });

}
