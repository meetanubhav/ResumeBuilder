function AjaxScripts() {
    //Ajax Script for edit section view
    $('body').on("click", ".save-basic-info", function (e) {
        var userData = new Object();
        userData.FirstName = $("[name = firstName]").val();
        userData.LastName = $("[name = lastName]").val();
        userData.Email = $("[name = email]").val();
        userData.PrimaryPhoneNumber = $("[name = primaryPhoneNumber]").val();
        userData.AlternatePhoneNumber = $("[name = altPhoneNumber]").val();
        ajaxFunct('/Resume/AddBasicInfo/',userData)
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