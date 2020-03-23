function AjaxScripts() {
    //Ajax Script for edit section view
    var ajaxFunction = function (url, type, formData, successFunction) {
        $.ajax({
            url: url,
            type: type,
            data: formData,
            success: function (response) {
                successFunction();           
            },
            failure: function (response) {
                alert("Ajax call failed");
            }
        })
    }

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

    $('body').on("click", ".save-basic-info", function (e) {
        e.preventDefault();
        var userData = {};
        userData.FirstName = $("[name = firstName]").val();
        userData.LastName = $("[name = lastName]").val();
        userData.Email = $("[name = email]").val();
        userData.PhoneNumber = $("[name = phoneNumber]").val();
        userData.AlternatePhoneNumber = $("[name = altPhoneNumber]").val();
        var successFunction = function () {
            $('.modal').modal('hide');
            getUserInfo();
        };

        ajaxFunction('/EditResume/AddBasicInfo', 'POST', userData, successFunction);
        return false;
    });

    $('body').on("click", ".save-summary-info", function (e) {
        e.preventDefault();
        var userData = {};
        userData.ResumeName = $("[name = ResumeName]").val();
        userData.Summary = $("[name = Summary]").val();

        var successFunction = function () {
            $('.modal').modal('hide');
            getUserInfo();
        };

        ajaxFunction('/EditResume/AddSummaryInfo', 'POST', userData, successFunction);
        return false;
    });

    $('body').on("click", ".save-education", function (e) {
        e.preventDefault();
        var userData = new Object();
        {
            userData.EduID = $('.education-form-id').val();
            userData.EducationLevel = ($('.form-check-input').serializeArray())[0]['value'];
            userData.YearOfPassing = $("[name = yop]").val();
            userData.CGPAorPercentage = ($('.form-check-input').serializeArray())[1]['value'];
            userData.Score = $("[name = gradetype]").val();
            userData.Stream = $("[name = stream]").val();
            userData.Institution = $("[name = university]").val();
        }

        var successFunction = function () {
            alert('edu saved');
        };

        ajaxFunction('/EditResume/AddOrUpdateEducation', 'POST', userData, successFunction);
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
        var successFunction = function () {
            console.log('settings updated');
        };
        ajaxFunction('/Settings/AddOrUpdateSettings', 'POST',formDetails, successFunction);
        return false;
    })

    //------------------------ CODE BY BHABANI-------------------------------------
    $('body').on("click", '.js-template', function () {

        $.ajax({
            url: "/Resume/GetTemplateDetails",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response != null) {

                    $.each(response, function (i, item) {
                        if (item.Organization != null) {
                            fromDate = new Date(parseInt(item.FromYear.substr(6)));
                            toDate = new Date(parseInt(item.ToYear.substr(6)));
                            var workDetails = $('.tWorkexperience').append($('<div class="font-weight-bold">').text(item.Organization + " (" + item.Designation + ")"),
                                                                     $('<div class="bg-light w-50 rounded">').text(fromDate.getFullYear() + " - " + toDate.getFullYear()));
                        }
                        //workDetails.html();
                    });
                    $.each(response, function (i, item) {
                        var projectDetails = $('.tproject').append($('<div class="font-weight-bold">').text(item.ProjectName),
                                                                 $('<div class="bg-light rounded">').text(item.ProjectDetails));

                        if (item.Skill != null) {
                            var skillDetails = $('.tskill').append($('<div class="font-weight-bold">').text(item.Skill),
                                                                     $('<div class="bg-light rounded rate">').text(item.Rating).append($("<i class='fas fa-star' style='color: #e6185e;'></i>")));
                        }
                        if (item.EducationLevel != null)
                            var educationDetails = $('.teducation').append($('<div class="font-weight-bold">').text(item.EducationLevel),
                                                                           $('<div class="bg-light rounded">').text("Scored " + item.CGPAorPercentage),
                                                                           $('<div class="bg-light rounded">').text(item.YearOfPassing));
                        if (item.LanguageName != null)
                            var languageKnown = $('.tlanguage').append($('<div class="bg-light rounded">').text(item.LanguageName));
                    });

                    $('.tName').text(response[5].FirstName + " " + response[5].LastName);
                    $('.tEmail').text(response[5].Email);
                    $('.tPhone').text(response[5].PhoneNumber);
                    $('.tResume').text(response[5].ResumeName);
                    $('.tSummary').text(response[5].Summary);
                    $('#test').text(response.Skill + " | Rating: " + response.Rating);
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
        $('.js-template').show();

        return false;
    });

    $('body').on("click", '.js-edit', function () {
        $.ajax({
            url: "/Resume/GetTemplateDetails",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('.summaryData').append($('<i class="far fa-edit float-right" data-summary-id="' + response[5].UserID + '"></i>'),
                                         $('<div class="font-weight-bold">').text(response[5].ResumeName),
                                         $('<div>').text(response[5].Summary));

                $.each(response, function (i, item) {
                    if (item.EducationLevel != null)
                        $('.educationData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2" data-education-id="' + item.EduID + '"></i><i class="fas fa-trash" data-skill-id="' + item.EduID + '"></i></div>'),
                                           $('<div class="font-weight-bold">').text(item.EducationLevel),
                                           $('<div>').text("Scored: " + item.Score));

                    if (item.Organization != null) {
                        fromDate = new Date(parseInt(item.FromYear.substr(6)));
                        toDate = new Date(parseInt(item.ToYear.substr(6)));
                        $('.workexpData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2" data-workexp-id="' + item.ExpId + '"></i><i class="fas fa-trash" data-skill-id="' + item.ExpId + '"></i></div>'),
                                                 $('<div class="font-weight-bold">').text(item.Organization + " (" + item.Designation + ")"),
                                                 $('<div class="bg-light w-50 rounded">').text(fromDate.getFullYear() + " - " + toDate.getFullYear()));
                    }

                    if (item.ProjectID != null)
                        $('.projectData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2" data-project-id="' + item.ProjectID + '"></i><i class="fas fa-trash" data-skill-id="' + item.ProjectID + '"></i></div>'),
                                                 $('<div class="font-weight-bold">').text(item.ProjectName),
                                                 $('<div class="bg-light rounded">').text(item.ProjectDetails));

                    if (item.LanguageName != null)
                        $('.languageData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2" data-language-id="' + item.LanguageID + '"></i><i class="fas fa-trash" data-skill-id="' + item.LanguageID + '"></i></div>'),
                                                  $('<div class="bg-light rounded">').text(item.LanguageName));

                    if (item.Skill != null)
                        $('.skillData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2" data-skill-id="' + item.UserSkillID + '"></i><i class="fas fa-trash" data-skill-id="' + item.UserSkillID + '"></i></div>'),
                                               $('<div class="font-weight-bold">').text(item.Skill),
                                               $('<div class="bg-light rounded rate">').text(item.Rating).append($("<i class='fas fa-star' style='color: #e6185e;'></i>")));
                });


            }
        });
    });

    $('body').on("click", ".su-edit", function (e) {
        e.preventDefault();
        var $button = $(this);
        var summaryId = $button.data('summary-id');
        $.ajax({
            url: "/EditResume/UpdateSummary/" + summaryId,
            method: "GET",
            success: function (result) {
                console.log(result);
                $('input[name="resumeName"]').val(result.ResumeName);
                $('textarea[name="summary"]').val(result.Summary);
                $('a')[5].click();
            },
            error: function (error) {
                console.log(error);
                alert("Sorry ! Unable to edit employee");
            }
        });


    });

    //------------------------END CODE OF BHABANI---------------------------------------------------

}
