function AjaxScripts() {
    /*              Save Buttons            */
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
        {
            userData.EduID = $('.js-education-id').val();
            userData.EducationLevel = ($('.form-check-input').serializeArray())[0]['value'];
            userData.CgpaOrPercentage = ($('.form-check-input').serializeArray())[1]['value'];
            userData.YearOfPassing = $("[name = YearOfPassing]").val();
            userData.Score = $("[name = Score]").val();
            userData.Board = $("[name = Board]").val();
            userData.Stream = $("[name = Stream]").val();
            userData.Institution = $("[name = Institution]").val();
        }
        ajaxFunction('/EditResume/AddEducationInfo', userData)
        return false;
    });

    $('body').on("click", ".save-skill", function (e) {
        e.preventDefault();
        var userData = new Object();
        {
            userData.SkillID = $('.js-skill-id').val();
            userData.SkillName = $("[name = skill]").val();
        }

        var successFunction = function () {
            alert('skill saved');
        };

        ajaxFunction('/EditResume/AddSkill', userData);
        return false;
    });

    $('body').on("click", ".save-project", function (e) {
        e.preventDefault();
        var userData = new Object();
        {
            userData.ProjectID = $('.js-project-id').val();
            userData.DurationInMonth = $("#projectDuration option:selected").val();
            userData.ProjectName = $("[name = projectName]").val();
            userData.ProjectDetails = $("[name = projectDetails]").val();
            userData.YourRole = $("[name = projectRole]").val();
        }

        var successFunction = function () {
            //$('.modal').modal('hide');
            console.log("Action Called");
        };

        ajaxFunction('/EditResume/AddProject', userData);
        return false;
    });

    $('body').on("click", ".save-workExp", function (e) {
        e.preventDefault();
        var userData = new Object();
        {
            userData.ExpId = $('.js-work-experience-id').val();
            userData.Organization = $("[name = organization]").val();
            userData.Designation = $("[name = designation]").val();
            userData.FromYear = $("[name = fromDate]").val();
            userData.ToYear = $("[name = toDate]").val();
        }

        var successFunction = function () {

            console.log("Action Called");
        };

        ajaxFunction('/EditResume/AddWorkExp', userData);
        return false;
    });

    $('body').on("click", ".save-language", function (e) {
        e.preventDefault();
        var userData = new Object();
        {
            userData.LanguageID = $('.js-language-id').val();
            userData.LanguageName = $("[name = language]").val();
        }

        var successFunction = function () {
            console.log('Language saved');
        };

        ajaxFunction('/EditResume/AddLanguage', userData);
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
        ajaxFunction('/Settings/AddOrUpdateSettings', formDetails);
        return false;
    });

    /*              Edit Buttons        */

    $('body').on('click', '.js-edit-education', function () {
        var $button = $(this);
        $button.find('.js-education-id').val();
        $button.find($('.form-check-input').serializeArray())[0]['value'];
        userData.CgpaOrPercentage = ($('.form-check-input').serializeArray())[1]['value'];
        userData.YearOfPassing = $("[name = YearOfPassing]").val();
        userData.Score = $("[name = Score]").val();
        userData.Board = $("[name = Board]").val();
        userData.Stream = $("[name = Stream]").val();
        userData.Institution = $("[name = Institution]").val();
    });

    $('body').on("click", ".pr-edit", function () {
        $('.project-form-id').val($(this).data('project-id'));
        $('a')[8].click();

    });

    $('body').on("click", ".lang-edit", function () {
        $('.language-form-id').val($(this).data('language-id'));
        $('a')[9].click();

    });

    $('body').on("click", ".sk-edit", function () {
        $('.skill-form-id').val($(this).data('skill-id'));
        $('a')[10].click();

    });

    $('.js-template, .js-edit-resume').on('click', function () {
        var $button = $(this);

        $.ajax({
            url: "/Resume/GetTemplateDetails",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response != null) {
                    currentData = response;
                    $.each(response.WorkExperience, function (i, item) {
                        if (item['ExpId'] != null) {
                            fromDate = new Date(parseInt(item['FromYear'].substr(6)));
                            toDate = new Date(parseInt(item['ToYear'].substr(6)));
                            var workDetails = $('.tWorkexperience').append($('<div class="font-weight-bold">').text(item['Organization'] + " (" + item['Designation'] + ")"),
                                                                     $('<div class="bg-light w-50 rounded">').text(fromDate.getFullYear() + " - " + toDate.getFullYear()));

                            $('.workexpData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 we-edit" data-workexp-id="' + item['ExpId'] + '"></i><i class="fas fa-trash we-delete" style="color: red;" data-workexp-id="' + item['ExpId'] + '"></i></div>'),
                                                     $('<div class="font-weight-bold">').text(item['Organization'] + " (" + item['Designation'] + ")"),
                                                     $('<div class="bg-light w-50 rounded">').text(fromDate.getFullYear() + " - " + toDate.getFullYear()));
                        }
                        //workDetails.html();
                    });

                    $.each(response.Project, function (i, item) {
                        var projectDetails = $('.tproject').append($('<div class="font-weight-bold">').text(item['ProjectName']),
                                                                 $('<div class="bg-light rounded">').text(item['ProjectDetails']));
                        $('.projectData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 pr-edit" data-project-id="' + item['ProjectID'] + '"></i><i class="fas fa-trash pr-delete" style="color: red;" data-project-id="' + item['ProjectID'] + '"></i></div>'),
                                                     $('<div class="font-weight-bold">').text(item['ProjectName']),
                                                     $('<div class="bg-light rounded">').text(item['ProjectDetails']));
                    });

                    $.each(response.Skill, function (i, item) {
                        if (item['SkillID'] != null) {
                            var skillDetails = $('.tskill').append($('<div class="font-weight-bold">').text(item['SkillName']));
                            $('.skillData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 sk-edit" data-skill-id="' + item['SkillID'] + '"></i><i class="fas fa-trash sk-delete" style="color: red;" data-skill-id="' + item['SkillID'] + '"></i></div>'),
                                                   $('<div class="font-weight-bold">').text(item['SkillName']));
                        }
                    });

                    $.each(response.Education, function (i, item) {
                        if (item['EducationLevel'] != null) {
                            var educationDetails = $('.teducation').append($('<div class="font-weight-bold">').text(item['EducationLevel']),
                                                                           $('<div class="bg-light rounded">').text("Scored: " + item['Score']),
                                                                           $('<div class="bg-light rounded">').text("Y.O.P: " + item['YearOfPassing']));
                            //-------Data Visible in Edit Page-------
                            $('.educationData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 edu-edit" data-education-id="' + item['EduID'] + '"></i><i class="fas fa-trash edu-delete" style="color: red;" data-education-id="' + item['EduID'] + '"></i></div>'),
                                           $('<div class="font-weight-bold">').text(item['EducationLevel']),
                                           $('<div>').text("Scored: " + item['Score']),
                                           $('<div>').text("Year of Passing: " + item['YearOfPassing']),
                                           $('<div>').text("Stream: " + item['Stream']));
                        }
                    });

                    $.each(response.Language, function (i, item) {
                        if (item['LanguageName'] != null) {
                            var languageKnown = $('.tlanguage').append($('<div class="bg-light rounded">').text(item['LanguageName']));
                            //-----Data Visible in Edit Page------------
                            $('.languageData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 lang-edit" data-language-id="' + item['LanguageID'] + '"></i><i class="fas fa-trash lang-delete" style="color: red;" data-language-id="' + item['LanguageID'] + '"></i></div>'),
                                                         $('<div class="bg-light font-weight-bold rounded">').text(item['LanguageName']));
                        }
                    });

                    $('.tName').text(response['FirstName'] + " " + response['LastName']);
                    $('.tEmail').text(response['Email']);
                    $('.tPhone').text(response['PhoneNumber']);
                    $('.tResume').text(response['ResumeName']);
                    $('.tSummary').text(response['Summary']);
                    //---Data visible in Edit Page
                    $('.summaryData').append($('<button class="far fa-edit float-right su-edit" data-summary-id="' + response['UserID'] + '"></button>'),
                                         $('<div class="font-weight-bold">').text(response['ResumeName']),
                                         $('<div>').text(response['Summary']));

                }

                else {
                    alert(response.responseText);
                }
            },
            error: function (response) {
                alert(response.responseText);
            }
        });

        if ($button.hasClass('js-template')) {

            $('.render-partial-view').load("/Resume/Template");
        }
        else if ($button.hasClass("js-edit-resume")) {
            $('.render-partial-view').load("/Resume/Edit", function () {
                EditSectionScripts();
            });
        }

        return false;
    });

    /*              Delete Buttons        */

    $('body').on("click", ".edu-edit, .edu-delete", function () {
        $button = $(this);
        if ($button.hasClass('edu-edit')) {
            $('.education-form-id').val($(this).data('education-id'));
            $('a')[6].click();
        }
        else if ($button.hasClass('edu-delete')) {

            var successFunction = function () {
                $button.parent().fadeOut();
                $button.parent().next().fadeOut();
                $button.parent().next().next().fadeOut();
            };
            confirmDelete(function (r) {
                if (r)
                    ajaxFunction('/EditResume/DeleteEducation', 'POST', { "eduId": $button.data('education-id') }, successFunction);
            })
        }


    });

    $('body').on('click', '.js-delete-education', function () {
        $.ajax({
            url: "/EditResume/DeleteEducation/" + $(this).attr("data-user-id"),
            contentType: 'application/json',
            method: "DELETE",
            success: function () {
                $(this).parent().remove();
            }
        });
    });

    $('body').on("click", ".we-edit, .we-delete", function () {
        $button = $(this);
        if ($button.hasClass('we-edit')) {
            $('.workExp-form-id').val($(this).data('workexp-id'));
            $('a')[7].click();
        }
        else if ($button.hasClass('we-delete')) {

            var successFunction = function () {
                $button.parent().fadeOut();
                $button.parent().next().fadeOut();
                $button.parent().next().next().fadeOut();
            };
            confirmDelete(function (r) {
                if (r)
                    ajaxFunction('/EditResume/DeleteWorkExperience', 'POST', { "expId": $button.data('workexp-id') }, successFunction);
            })
        }


    });

    $('body').on("click", ".pr-edit, .pr-delete", function () {
        $button = $(this);
        if ($button.hasClass('pr-edit')) {
            $('.project-form-id').val($(this).data('project-id'));
            $('a')[8].click();
        }
        else if ($button.hasClass('pr-delete')) {

            var successFunction = function () {
                $button.parent().fadeOut();
                $button.parent().next().fadeOut();
                $button.parent().next().next().fadeOut();
            };
            confirmDelete(function (r) {
                if (r)
                    ajaxFunction('/EditResume/DeleteProject', 'POST', { "projectId": $button.data('project-id') }, successFunction);
            })
        }
    });

    $('body').on("click", ".lang-edit, .lang-delete", function () {
        $button = $(this);
        if ($button.hasClass('lang-edit')) {
            $('.language-form-id').val($(this).data('language-id'));
            $('a')[9].click();
        }
        else if ($button.hasClass('lang-delete')) {

            var successFunction = function () {
                $button.parent().fadeOut();
                $button.parent().next().fadeOut();
            };
            confirmDelete(function (r) {
                if (r)
                    ajaxFunction('/EditResume/DeleteLanguage', 'POST', { "languageId": $button.data('language-id') }, successFunction);
            })
        }

    });

    $('body').on("click", ".sk-edit, .sk-delete", function () {
        $button = $(this);
        if ($button.hasClass('sk-edit')) {
            $('.skill-form-id').val($(this).data('skill-id'));
            $('a')[10].click();
        }
        else if ($button.hasClass('sk-delete')) {

            var successFunction = function () {
                $button.parent().fadeOut();
                $button.parent().next().fadeOut();
            };
            confirmDelete(function (r) {
                if (r)
                    ajaxFunction('/EditResume/DeleteSkill', 'POST', { "skillId": $button.data('skill-id') }, successFunction);
            })
        }

    });

    function confirmDelete(callback) {
        bootbox.confirm({
            title: "Delete Data",
            message: "Do you really want to delete ? This cannot be undone.",
            buttons: {
                cancel: {
                    label: '<i class="fa fa-times"></i> Cancel'
                },
                confirm: {
                    label: '<i class="fa fa-check"></i> Confirm'

                }
            },
            callback: function (result) {
                console.log('This was logged in the callback: ' + result);
                callback(result);
            }
        });
    }   

    // COMMON FUNCTION FOR AJAX POST CALLS
    var ajaxFunction = function (url, formData) {
        $.ajax({
            url: url,
            type: 'POST',
            data: formData,
            success: function (response) {
                getUserInfo();
                $('.toast').toast('show');
                $('.render-partial-view').load("/Resume/Edit");
                $('.modal').modal('hide');
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();
                //$('.show-content').html(response);
            },
            failure: function (response) {
                

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
