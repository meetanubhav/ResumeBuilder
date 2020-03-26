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

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/AddBasicInfo';
        params['data'] = userData;
        params['requestType'] = 'POST';
        params['successCallbackFunction'] = function (userData) {
            $("[name = FirstName]").val(userData.FirstName);
            $("[name = LastName]").val(userData.LastName);
            $("[name = Email]").val(userData.Email);
            $("[name = PhoneNumber]").val(userData.PhoneNumber);
            $("[name = AlternatePhoneNumber]").val(userData.AlternatePhoneNumber);
            
            //Adding data in the fields
            $(".show-name").text(userData.FirstName + " " + userData.LastName);
            $(".show-email").text(userData.Email);
            $(".show-phone-number").text(userData.PhoneNumber);
            $(".show-alt-phone-number").text(userData.AlternatePhoneNumber);
        };
        doAjax(params);

        return false;
    });

    $('body').on("click", ".save-summary-info", function (e) {
        e.preventDefault();

        var userData = {};
        userData.ResumeName = $("[name = ResumeName]").val();
        userData.Summary = $("[name = Summary]").val();

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/AddSummaryInfo';
        params['data'] = userData;
        params['requestType'] = 'POST';
        params['successCallbackFunction'] = function (userData) {
            $("[name = ResumeName]").val(userData.ResumeName);
            $("[name = Summary]").val(userData.Summary);

            $(".show-summary-info").text(userData.Summary);
            $(".show-resume-info").text(userData.ResumeName);
        };
        doAjax(params);

        return false;
    });

    $('body').on("click", ".save-education-info", function (e) {
        e.preventDefault();
        var id = $('.js-education-id').val();
        var $button = $('button [data-education-id="'+id+'"]');

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

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/AddEducationInfo';
        params['data'] = userData;
        params['requestType'] = 'POST';
        params['successCallbackFunction'] = function (data) {
            if (!(userData.EduID > 0))
            {
                $('.js-education-details').append('<div class="row text-secondary"> \
                     <hr width="90%">\
                        <div class="col-md-10 col-sm-8"> \
                            <p> ' + data.Score + ' ' + data.CGPAorPercentage + ' in ' + data.EducationLevel + '</p> \
                            <p> ' + data.YearOfPassing + '</p> \
                            <p>' + data.Stream + '</p> \
                            <p> ' + data.Institution + '</p> \
                        </div> \
                        <div class="col-md-2 col-sm-4"> \
                            <button class="btn btn-sm btn-primary"><i class="fa fa-edit text-white js-edit-education" data-education-id="' + data.EduID + '"></i></button> \
                            <button class="btn btn-sm btn-danger"><i class="fa fa-trash-alt text-white js-delete-education" data-education-id="' + data.EduID + '"></i></button> \
                        </div> \
                    </div>');
            }
            else
            {
                $button.parents('.text-secondary').html('<hr width="90%">\
                        <div class="col-md-10 col-sm-8"> \
                            <p> ' + data.Score + ' ' + data.CGPAorPercentage + ' in ' + data.EducationLevel + '</p> \
                            <p> ' + data.YearOfPassing + '</p> \
                            <p>' + data.Stream + '</p> \
                            <p> ' + data.Institution + '</p> \
                        </div> \
                        <div class="col-md-2 col-sm-4"> \
                            <button class="btn btn-sm btn-primary"><i class="fa fa-edit text-white js-edit-education" data-education-id="' + data.EduID + '"></i></button> \
                            <button class="btn btn-sm btn-danger"><i class="fa fa-trash-alt text-white js-delete-education" data-education-id="' + data.EduID + '"></i></button> \
                        </div>');
            }

        };
        doAjax(params);

        return false;
    });

    $('body').on("click", ".save-skill", function (e) {
        e.preventDefault();
        var $button = $(this);

        var userData = new Object();
        {
            userData.SkillID = $('.js-skill-id').val();
            userData.SkillName = $("[name = skill]").val();
        }

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/AddSkill';
        params['data'] = userData;
        params['requestType'] = 'POST';
        params['successCallbackFunction'] = function (data) {
            $('.js-skill-details').append('<span class="btn btn-primary"> \
                    '+data.SkillName+' \
                <i class="fa fa-times js-delete-skill text-danger" data-skill-id="'+data.SkillID+'"> </i> \
                    </span>');
       };
        doAjax(params);

        return false;
    });

    $('body').on("click", ".save-project", function (e) {
        e.preventDefault();
        var id = $('.js-project-id').val();
        var $button = $('button [data-project-id="' + id + '"]');

        var userData = new Object();
        {
            userData.ProjectID = $('.js-project-id').val();
            userData.DurationInMonth = $("#projectDuration option:selected").val();
            userData.ProjectName = $("[name = projectName]").val();
            userData.ProjectDetails = $("[name = projectDetails]").val();
            userData.YourRole = $("[name = projectRole]").val();
        }

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/AddProject';
        params['data'] = userData;
        params['requestType'] = 'POST';
        params['successCallbackFunction'] = function (data) {
            var $html = '<hr width="90%" /> \
                    <div class="col-md-10 col-sm-8 "> \
                        <h5>'+ data.ProjectName + '</h5> \
                        <p>Duration '+ data.DurationInMonth + 'months</p> \
                        <p>'+ data.ProjectDetails + '</p> \
                    </div> \
                    <div class="col-md-2 col-sm-4"> \
                        <button class="btn btn-sm btn-primary"><i class="fa fa-edit text-white js-edit-project" data-project-id="'+ data.ProjectID + '"></i></button> \
                        <button class="btn btn-sm btn-danger"><i class="fa fa-trash-alt text-white js-delete-project" data-project-id="' + data.ProjectID + '"></i></button> \
                    </div>';

            if (!(userData.ProjectID > 0)) {
                $('.js-project-details').append('<div class="row" '+ $html + '</div>');
            }
            else {
                $button.parents('.row').html($html);
            }

        };
        doAjax(params);

        return false;
    });

    $('body').on("click", ".save-workExp", function (e) {
        e.preventDefault();
        var id = $('.js-work-experience-id').val();
        var $button = $('button [data-workexp-id="' + id + '"]');

        var userData = new Object();
        {
            userData.ExpId = $('.js-work-experience-id').val();
            userData.Organization = $("[name = organization]").val();
            userData.Designation = $("[name = designation]").val();
            userData.FromYear = $("[name = fromDate]").val();
            userData.ToYear = $("[name = toDate]").val();
        }

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/AddWorkExp';
        params['data'] = userData;
        params['requestType'] = 'POST';
        params['successCallbackFunction'] = function (data) {
            var $html = '<hr width="90%" /> \
                    <div class="col-md-10 col-sm-8"> \
                        <p> \
                            <b> '+data.Designation +'</b> at <b> '+data.Organization +'</b> \
                            <br /> \
                            <b> '+data.FromYear +'</b> - <b> '+data.ToYear +'</b> \
                        </p> \
                    </div> \
                    <div class="col-md-2 col-sm-4"> \
                        <button class="btn btn-sm btn-primary"><i class="fa fa-edit text-white js-edit-workexp" data-workexp-id="'+data.ExpId+'"></i></button> \
                        <button class="btn btn-sm btn-danger"><i class="fa fa-trash-alt text-white js-delete-workexp" data-workexp-id="'+data.ExpId+'"></i></button> \
                    </div>';
            if (!(userData.ExpId > 0)) {
                $('.js-work-experience-details').append('<div class="row" '+ $html + '</div>');
            }
            else {
                $button.parents('.row').html($html);
            }

        };
        doAjax(params);

        return false;
    });

    $('body').on("click", ".save-language", function (e) {
        e.preventDefault();
        var $button = $(this);

        var userData = new Object();
        {
            userData.LanguageID = $('.js-language-id').val();
            userData.LanguageName = $("[name = language]").val();
        }

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/AddLanguage';
        params['data'] = userData;
        params['requestType'] = 'POST';
        params['successCallbackFunction'] = function (data) {
            $('.js-language-details').append('<span class="btn btn-primary"> \
                    ' + data.LanguageName +' \
                    <i class="fa fa-times js-delete-language text-danger" data-skill-id="'+data.LanguageID+'"> </i> \
                    </span>');
        };
        doAjax(params);

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

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/Settings/AddOrUpdateSettings';
        params['data'] = formDetails;
        params['requestType'] = 'POST';
        params['dataType'] = null;
        
        doAjax(params);

        return false;
    });

    /*              Edit Buttons        */

    $('body').on('click', '.js-edit-education', function () {
        var $button = $(this);
        var educationId = $button.data('education-id');

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/GetEducation?educationId='+educationId;
        params['successCallbackFunction'] = function (data) {
            var $form = $('.education-form');
            $form.find('.js-education-id').val(data.EduID);
            $form.find('input[value="' + data.EducationLevel + '"]').prop('checked', true);
            $form.find('input[value="' + data.CGPAorPercentage + '"]').prop('checked', true);
            $form.find("[name = YearOfPassing]").val(data.YearOfPassing);
            $form.find("[name = Score]").val(data.Score);
            $form.find("[name = Board]").val(data.Board);
            $form.find("[name = Stream]").val(data.Stream);
            $form.find("[name = Institution]").val(data.Institution);
            $('a[data-target=".educationModal"]').click()
        };

        doAjax(params);
    });

    $('body').on("click", ".js-edit-project", function () {
        var $button = $(this);
        var projectId = $button.data('project-id');

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/GetProject?projectId=' + projectId;
        params['successCallbackFunction'] = function (data) {
            var $form = $('.project-form');
            $form.find('.js-project-id').val(data.ProjectID);
            $form.find('[name = projectName]').val(data.ProjectName);
            $form.find('[name = projectDetails]').val(data.projectDetails);
            $form.find("[name = projectRole]").val(data.YourRole);
            $form.find("#projectDuration").val(data.DurationInMonth);
            $('a[data-target=".projectModal"]').click()
        };

        doAjax(params);

    });

    $('body').on("click", ".js-edit-workexp", function () {
        var $button = $(this);
        var workExperienceId = $button.data('workexp-id');

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/GetWorkExperience?workExperienceId=' + workExperienceId;
        params['successCallbackFunction'] = function (data) {
            var $fromDate = data.FromYear.getFullYear() + '-' + data.FromYear.getMonth() + '-' + data.FromYear.getDate();
            var $toDate = data.ToYear.getFullYear() + '-' + data.ToYear.getMonth() + '-' + data.ToYear.getDate();
            var $form = $('.workExp-form');
            $form.find('.js-work-experience-id').val(data.ExpId);
            $form.find('[name = organization]').val(data.Organization);
            $form.find('[name = designation]').val(data.Designation);
            $form.find("[name = fromDate]").val($fromDate);
            $form.find("[name = toDate]").val($toDate);
            $('a[data-target=".workExperienceModal"]').click()
        };

        doAjax(params);

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

    $('body').on('click', '.js-delete-education', function () {
        var $button = $(this);
        var id = $button.data('education-id');

        var params = $.extend({}, doAjax_params_default);
        params['url'] = '/EditResume/DeleteEducation?id='+id;
        params['requestType'] = 'DELETE';
        params['dataType'] = 'text';
        params['successCallbackFunction'] = function (data) {
            $button.parents('.text-secondary').remove();
        };

        confirmDelete(function (result) {
            if(result)
            {
                doAjax(params);
            }
        })
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
    //var ajaxFunction = function (url, formData) {
    //    $.ajax({
    //        url: url,
    //        type: 'POST',
    //        data: formData,
    //        success: function (response) {
    //            getUserInfo();
    //            $('.modal').modal('hide');
    //            $('body').removeClass('modal-open');
    //            $('.modal-backdrop').remove();
    //            $('modal input[type="text"]').val('');
    //            $('modal input[type ="checkbox"]').prop('checked', false);
    //            //$('.show-content').html(response);
    //        },
    //        failure: function (response) {
    //            alert("fail ho gya bhai");
    //        }
    //    })
    //}
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

String.prototype.endsWith = function (suffix) {
    return this.indexOf(suffix, this.length - suffix.length) !== -1;
};

var doAjax_params_default = {
    'url': null,
    'requestType': "GET",
    'contentType': 'application/x-www-form-urlencoded; charset=UTF-8',
    'dataType': 'json',
    'data': {},
    'beforeSendCallbackFunction': null,
    'successCallbackFunction': null,
    'completeCallbackFunction': null,
    'errorCallBackFunction': null,
};


function doAjax(doAjax_params) {

    var url = doAjax_params['url'];
    var requestType = doAjax_params['requestType'];
    var contentType = doAjax_params['contentType'];
    var dataType = doAjax_params['dataType'];
    var data = doAjax_params['data'];
    var beforeSendCallbackFunction = doAjax_params['beforeSendCallbackFunction'];
    var successCallbackFunction = doAjax_params['successCallbackFunction'];
    var completeCallbackFunction = doAjax_params['completeCallbackFunction'];
    var errorCallBackFunction = doAjax_params['errorCallBackFunction'];

    //make sure that url ends with '/'
    /*if(!url.endsWith("/")){
     url = url + "/";
    }*/

    $.ajax({
        url: url,
        crossDomain: true,
        type: requestType,
        contentType: contentType,
        dataType: dataType,
        data: data,
        beforeSend: function (jqXHR, settings) {
            if (typeof beforeSendCallbackFunction === "function") {
                beforeSendCallbackFunction();
            }
        },
        success: function (data, textStatus, jqXHR) {
            if (typeof successCallbackFunction === "function") {
                successCallbackFunction(data);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (typeof errorCallBackFunction === "function") {
                errorCallBackFunction(errorThrown);
            }

        },
        complete: function (jqXHR, textStatus) {
            if (typeof completeCallbackFunction === "function") {
                completeCallbackFunction();
            }
        }
    });
}