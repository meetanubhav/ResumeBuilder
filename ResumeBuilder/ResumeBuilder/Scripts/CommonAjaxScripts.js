function AjaxScripts() {

    //Ajax Script by bhabani
    $('.save-basic-info').on("click", function () {

        //var formData = $('.basic-info-form').serialize();
        var userData = new Object();
        userData.firstName = $("[name = firstName]").val();
        userData.lastName = $("[name = lastName]").val();
        userData.email = $("[name = email]").val();
        userData.phoneNumber = parseInt($("[name = phoneNumber]").val());
        userData.altphoneNumber = parseInt($("[name = altphoneNumber]").val());
        $.ajax({
            url: "/EditResume/AddBasicInformation",
            method: "POST",
            data: JSON.stringify(userData),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //alert("Data Saved Successfully");
                $(".basic-info-form input").prop("disabled", true);
            }
        });
        //$(this).parent().next().next().show(300);
    });

//------- Universal AJAX Function ----------------------
    var ajaxFunc = function (url, formdata, message) {
        $.ajax({
            url: url,
            method: "POST",
            data: formdata,
            dataType: "json",
            success: function(){    
                alert("Sent Successfully")
            }
        });
    }
//------------------------------------------------------
    $('.btn-save').on("click", function () {
        if ($(this).parent().attr('class') === 'summary-form')
            url = '/EditResume/Summary';

        var formData = $(this).parent().serialize();

        ajaxFunc(url, formData, "Testing");
        $(this).parent().parent().next().next().show(300);
    });

//---------------------------------------------------------------------------------
    $('#template').on("click", function () {
        
        $.ajax({
            url: "/Resume/GetSkillDetails",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response != null) {
                    $('.skills #test').text(response.Skill);
                    //alert(response.Skill);
                }
                else {
                    alert(response.responseText);
                }
            }, failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
        $('.show-template-section').show();

        return false;
    });
}