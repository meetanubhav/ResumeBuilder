function AjaxScripts() {
    //Ajax Script for edit section view
    $('body').on("click", ".save-basic-info", function (e) {
        var userData = new Object();
        userData.userID = $("#userId").val();
        userData.firstName = $("[name = firstName]").val();
        userData.lastName = $("[name = lastName]").val();
        userData.email = $("[name = email]").val();
        userData.primaryPhoneNumber = $("[name = primaryPhoneNumber]").val();
        userData.altPhoneNumber = $("[name = altPhoneNumber]").val();
        ajaxFunct('/Resume/AddBasicInfo/', { user: userData })
        return false;
    });
    var ajaxFunct = function (url, formData) {
        $.ajax({
            url: url,
            contentType: 'application/html; charset=utf-8',
            type: 'POST',
            data: formData,
            dataType: "json",
            success: function (response) {
                //$('.show-content').html(response);
            },
            failure: function (response) {
            }
        })
    }

}