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
        ajaxFunction('/EditResume/AddBasicInfo', userData)
        return false;
    });
    $('body').on("click", ".save-summary-info", function (e) {
        e.preventDefault();
        var userData = {};
        userData.ResumeName = $("[name = ResumeName]").val();
        userData.Summary = $("[name = Summary]").val();
        ajaxFunction('/EditResume/AddSummaryInfo', userData)
        return false;
    });

    $('body').on("click", ".save-education-info", function (e) {
        e.preventDefault();
        var userData = {};
        userData.EducationLevel = ($('.form-check-input').serializeArray())[0]['value'];
        userData.cgpaOrPercentage = ($('.form-check-input').serializeArray())[1]['value'];
        userData.YearOfPassing = $("[name = YearOfPassing]").val();
        userData.Score = $("[name = Score]").val();
        userData.Board = $("[name = Board]").val();
        userData.Stream = $("[name = Stream]").val();
        userData.Institution = $("[name = Institution]").val();
        ajaxFunction('/EditResume/AddEducationInfo', userData)
        return false;
    });

    $('body').on('click', '.js-delete-education', function () {
        $(this).parent().parent().remove();
        $.ajax({
            url: "/EditResume/DeleteEducation/" + $(this).attr("data-user-id"),
            contentType: 'application/json',
            method: "DELETE",
            success: function () {

            }
        });
    });
    $('body').on("click", ".save-work-experience", function (e) {
        e.preventDefault();
        var userData = {};
        userData.Organization = $("[name = Organization]").val();
        userData.Designation = $("[name = Designation]").val();
        userData.FromYear = $("[name = FromYear]").val();
        userData.ToYear = $("[name = ToYear]").val();
        ajaxFunction('/EditResume/AddWorkExperience', userData)
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


    // COMMON FUNCTION FOR AJAX POST CALLS
    var ajaxFunction = function (url, formData) {
        $.ajax({
            url: url,
            type: 'POST',
            data: formData,
            success: function (response) {
                getUserInfo();
                $('.modal').modal('hide');
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();
                $('modal input[type="text"]').val('');
                $('modal input[type ="checkbox"]').prop('checked', false);
                //$('.show-content').html(response);
            },
            failure: function (response) {
                alert("fail ho gya bhai");
            }
        })
    }
}

// COMMON FUNCTION FOR AJAX GET CALLS
function getUserInfo() {
    $.ajax({
        url: "/EditResume/GetUserInfo",
        type: "GET",
        dataType: "json",
        success: function (userData) {
            $("[name = FirstName]").val(userData.FirstName);
            $("[name = LastName]").val(userData.LastName);
            $("[name = Email]").val(userData.Email);
            $("[name = PhoneNumber]").val(userData.PhoneNumber);
            $("[name = AlternatePhoneNumber]").val(userData.AlternatePhoneNumber);
            $("[name = ResumeName]").val(userData.ResumeName);
            $("[name = Summary]").val(userData.Summary);

            //Adding data in the fields
            $(".show-name").text(userData.FirstName + " " + userData.LastName);
            $(".show-email").text(userData.Email);
            $(".show-phone-number").text(userData.PhoneNumber);
            $(".show-alt-phone-number").text(userData.AlternatePhoneNumber);
            $(".show-summary-info").text(userData.Summary);
            $(".show-resume-info").text(userData.ResumeName);
        }
    })
}