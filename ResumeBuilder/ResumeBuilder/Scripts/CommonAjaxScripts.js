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

    $('body').on('click', '.save-settings', function () {
        var form = $(this).parent('form');
        var formDetails = new Object();
        {
            formDetails.Education = form.find('#settingFormEducation').is(':checked');
            formDetails.Language = form.find('#settingFormLanguage').is(':checked');
            formDetails.Project = form.find('#settingFormProject').is(':checked');
            formDetails.Skill = form.find('#settingFormSkill').is(':checked');
            formDetails.WorkExperience = form.find('#settingFormWorkExperience').is(':checked');
        }
        ajaxFunction('/Settings/AddOrUpdateSettings', formDetails, 'success');
        return false;
    })
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