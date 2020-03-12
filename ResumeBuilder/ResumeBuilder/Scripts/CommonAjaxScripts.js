function AjaxScripts() {
    //Ajax Script for edit section view

    $('body').on("click", '.save-basic-info', function (e) {
        var userData = new Object();
        {
            userData.userID = $("#userId").val();
            userData.firstName = $("[name = firstName]").val();
            userData.lastName = $("[name = lastName]").val();
            userData.email = $("[name = email]").val();
            userData.PhoneNumber = $("[name = primaryPhoneNumber]").val();
            userData.AlternatePhoneNumber = $("[name = altPhoneNumber]").val();
        }

        ajaxFunc('/EditResume/AddBasicInformation', userData, 'success');

        return false;
    });

    var ajaxFunc = function (url, formData, message) {
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