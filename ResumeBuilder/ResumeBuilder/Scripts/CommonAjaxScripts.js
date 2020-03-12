function AjaxScripts() {
    //Ajax Script for edit section view
    $('body').on("click", ".save-basic-info", function (e) {
        var userData = {};
        userData.FirstName = $("[name = firstName]").val();
        userData.LastName = $("[name = lastName]").val();
        userData.Email = $("[name = email]").val();
        userData.PrimaryPhoneNumber = $("[name = primaryPhoneNumber]").val();
        userData.AlternatePhoneNumber = $("[name = altPhoneNumber]").val();
        ajaxFunct('/EditResume/AddBasicInfo', userData)
        return false;
    });
    var ajaxFunct = function (url, formData) {
        $.ajax({
            url: url,
            type: 'POST',
            data: formData,
            success: function (response) {
                //$('.show-content').html(response);
            },
            failure: function (response) {
            }
        })
    }
}