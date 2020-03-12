function AjaxScripts() {
    //Ajax Script for edit section view
    $('body').on("click", ".save-basic-info", function (e) {
        e.preventDefault();
        var userData = {};
        userData.FirstName = $("[name = FirstName]").val();
        userData.LastName = $("[name = LastName]").val();
        userData.Email = $("[name = Email]").val();
        userData.PhoneNumber = $("[name = PhoneNumber]").val();
        userData.AlternatePhoneNumber = $("[name = AlternatePhoneNumber]").val();
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
