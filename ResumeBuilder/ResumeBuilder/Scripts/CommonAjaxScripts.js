function AjaxScripts() {

    //Ajax Script by bhabani
    $('.save-basic-info').on("click", function () {

        //var formData = $('.basic-info-form').serialize();
        var userData = new Object();
        userData.firstName = $("[name = firstName]").val();
        userData.lastName = $("[name = lastName]").val();
        userData.email = $("[name = email]").val();
        userData.phoneNumber = parseInt($("[name = phoneNumber]").val());
        $.ajax({
            url: "/EditResume/AddBasicInformation",
            method: "POST",
            data: JSON.stringify(userData),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $(".save-basic-info input").prop("disabled", true);
            }
        });
        $(this).parent().next().next().show(300);
    });


    var ajaxFunc = function (url, formdata, message) {
        $.ajax({
            url: url,
            method: "POST",
            data: formdata,
            dataType: "json",
            success: function () {
                alert("Sent Successfully")
            }
        });
    }

}