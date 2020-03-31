function AjaxScripts() {
    /*              Save Basic Information            */
    $('body').on("click", ".save-basic-info", function (e) {
        e.preventDefault();

        var userData = {};
        userData.FirstName = $("input[name = FirstName]").val();
        userData.LastName = $("input[name = LastName]").val();
        userData.Email = $("input[name = Email]").val();
        userData.PhoneNumber = $("input[name = PhoneNumber]").val();
        userData.AlternatePhoneNumber = $("input[name = AlternatePhoneNumber]").val();

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/AddBasicInfo';
        parameter['data'] = userData;
        parameter['requestType'] = 'POST';
        parameter['successCallbackFunction'] = function (userData) {
            $("input[name = FirstName]").val(userData.FirstName);
            $("input[name = LastName]").val(userData.LastName);
            $("input[name = Email]").val(userData.Email);
            $("input[name = PhoneNumber]").val(userData.PhoneNumber);
            $("input[name = AlternatePhoneNumber]").val(userData.AlternatePhoneNumber);

            //Adding data in the fields
            $(".show-name").text(userData.FirstName + " " + userData.LastName);
            $(".show-email").text(userData.Email);
            $(".show-phone-number").text(userData.PhoneNumber);
            $(".show-alt-phone-number").text(userData.AlternatePhoneNumber);

            $('.modal').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        };
        doAjax(parameter);

        return false;
    });

    /*              Save Summary Information            */

    $('body').on("click", ".save-summary-info", function (e) {
        e.preventDefault();

        var userData = {};
        userData.ResumeName = $("input[name = ResumeName]").val();
        userData.Summary = $("input[name = Summary]").val();

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/AddSummaryInfo';
        parameter['data'] = userData;
        parameter['requestType'] = 'POST';
        parameter['successCallbackFunction'] = function (userData) {
            $("input[name = ResumeName]").val(userData.ResumeName);
            $("input[name = Summary]").val(userData.Summary);

            $(".show-summary-info").text(userData.Summary);
            $(".show-resume-info").text(userData.ResumeName);

            $('.modal').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        };
        doAjax(parameter);

        return false;
    });

    /*              Save Education Information            */

    $('body').on("click", ".save-education-info", function (e) {
        e.preventDefault();
        var id = $('.js-education-id').val();
        var $button = $('button [data-education-id="' + id + '"]');

        var userData = {};
        {
            userData.EduID = $('.js-education-id').val();
            userData.EducationLevel = ($('.form-check-input').serializeArray())[0]['value'];
            userData.CgpaOrPercentage = ($('.form-check-input').serializeArray())[1]['value'];
            userData.YearOfPassing = $("input[name = YearOfPassing]").val();
            userData.Score = $("input[name = Score]").val();
            userData.Board = $("input[name = Board]").val();
            userData.Stream = $("input[name = Stream]").val();
            userData.Institution = $("input[name = Institution]").val();
        }

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/AddEducationInfo';
        parameter['data'] = userData;
        parameter['requestType'] = 'POST';
        parameter['successCallbackFunction'] = function (data) {
            if (!(userData.EduID > 0)) {
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
            else {
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

            $('.modal').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();

        };
        doAjax(parameter);

        return false;
    });

    /*              Save Skills Information            */

    $('body').on("click", ".save-skill", function (e) {
        e.preventDefault();
        var $button = $(this);

        var userData = new Object();
        {
            userData.SkillID = $('.js-skill-id').val();
            userData.SkillName = $("input[name = skill]").val();
        }

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/AddSkill';
        parameter['data'] = userData;
        parameter['requestType'] = 'POST';
        parameter['successCallbackFunction'] = function (data) {
            $('.js-skill-details').append('<span class="btn btn-primary"> \
                    '+ data.SkillName + ' \
                <i class="fa fa-times js-delete-skill text-danger" data-skill-id="'+ data.SkillID + '"> </i> \
                    </span>');

            $('.modal').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        };
        doAjax(parameter);

        return false;
    });

    /*              Save Project Information            */

    $('body').on("click", ".save-project", function (e) {
        e.preventDefault();
        var id = $('.js-project-id').val();
        var $button = $('button [data-project-id="' + id + '"]');

        var userData = new Object();
        {
            userData.ProjectID = $('.js-project-id').val();
            userData.DurationInMonth = $("#projectDuration option:selected").val();
            userData.ProjectName = $("input[name = projectName]").val();
            userData.ProjectDetails = $("input[name = projectDetails]").val();
            userData.YourRole = $("input[name = projectRole]").val();
        }

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/AddProject';
        parameter['data'] = userData;
        parameter['requestType'] = 'POST';
        parameter['successCallbackFunction'] = function (data) {
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
                $('.js-project-details').append('<div class="row" >' + $html + '</div>');
            }
            else {
                $button.parents('.row').html($html);
            }

            $('.modal').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();

        };
        doAjax(parameter);

        return false;
    });

    /*              Save Work Experience Information            */

    $('body').on("click", ".save-workExp", function (e) {
        e.preventDefault();
        var id = $('.js-work-experience-id').val();
        var $button = $('button [data-workexp-id="' + id + '"]');

        var userData = new Object();
        {
            userData.ExpId = $('.js-work-experience-id').val();
            userData.Organization = $("input[name = organization]").val();
            userData.Designation = $("input[name = designation]").val();
            userData.FromYear = $("input[name = fromDate]").val();
            userData.ToYear = $("input[name = toDate]").val();
        }

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/AddWorkExp';
        parameter['data'] = userData;
        parameter['requestType'] = 'POST';
        parameter['successCallbackFunction'] = function (data) {
            var $date = new Date(parseInt((data.FromYear).substr(6)));
            var $fromDate = $date.getMonth() + '/' + $date.getDate() + '/' + $date.getFullYear();

            $date = new Date(parseInt((data.ToYear).substr(6)));
            var $toDate = $date.getMonth() + '/' + $date.getDate() + '/' + $date.getFullYear();
            var $html = '<hr width="90%" /> \
                    <div class="col-md-10 col-sm-8"> \
                        <p> \
                            <b> '+ data.Designation + '</b> at <b> ' + data.Organization + '</b> \
                            <br /> \
                            <b> '+ $fromDate + '</b> - <b> ' + $toDate + '</b> \
                        </p> \
                    </div> \
                    <div class="col-md-2 col-sm-4"> \
                        <button class="btn btn-sm btn-primary"><i class="fa fa-edit text-white js-edit-workexp" data-workexp-id="'+ data.ExpId + '"></i></button> \
                        <button class="btn btn-sm btn-danger"><i class="fa fa-trash-alt text-white js-delete-workexp" data-workexp-id="'+ data.ExpId + '"></i></button> \
                    </div>';
            if (!(userData.ExpId > 0)) {
                $('.js-work-experience-details').append('<div class="row" >' + $html + '</div>');
            }
            else {
                $button.parents('.row').html($html);
            }

            $('.modal').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();

        };
        doAjax(parameter);

        return false;
    });

    /*              Save Language Information            */

    $('body').on("click", ".save-language", function (e) {
        e.preventDefault();
        var $button = $(this);
        var userData = new Object();
        {
            userData.LanguageID = $('.js-language-id').val();
            userData.LanguageName = $("input[name = language]").val();
        }

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/AddLanguage';
        parameter['data'] = userData;
        parameter['requestType'] = 'POST';
        parameter['successCallbackFunction'] = function (data) {
            $('.js-language-details').append('<span class="btn btn-primary"> \
                    ' + data.LanguageName + ' \
                    <i class="fa fa-times js-delete-language text-danger" data-language-id="'+ data.LanguageID + '"> </i> \
                    </span>');

            $('.modal').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        };
        doAjax(parameter);

        return false;
    });

    /*              Save Settings            */

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

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/Settings/AddOrUpdateSettings';
        parameter['data'] = formDetails;
        parameter['requestType'] = 'POST';
        parameter['dataType'] = null;

        doAjax(parameter);

        return false;
    });

    /*              Edit Buttons        */

    $('body').on('click', '.js-edit-education', function () {
        var $button = $(this);
        var educationId = $button.data('education-id');

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/GetEducation?educationId=' + educationId;
        parameter['successCallbackFunction'] = function (data) {
            var $form = $('.education-form');
            $form.find('.js-education-id').val(data.EduID);
            $form.find('input[value="' + data.EducationLevel + '"]').prop('checked', true);
            $form.find('input[value="' + data.CGPAorPercentage + '"]').prop('checked', true);
            $form.find("input[name = YearOfPassing]").val(data.YearOfPassing);
            $form.find("input[name = Score]").val(data.Score);
            $form.find("input[name = Board]").val(data.Board);
            $form.find("input[name = Stream]").val(data.Stream);
            $form.find("input[name = Institution]").val(data.Institution);
            $('a[data-target=".educationModal"]').click()
        };

        doAjax(parameter);
    });

    $('body').on("click", ".js-edit-project", function () {
        var $button = $(this);
        var projectId = $button.data('project-id');

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/GetProject?projectId=' + projectId;
        parameter['successCallbackFunction'] = function (data) {
            var $form = $('.project-form');
            $form.find('.js-project-id').val(data.ProjectID);
            $form.find('input[name = projectName]').val(data.ProjectName);
            $form.find('input[name = projectDetails]').val(data.projectDetails);
            $form.find("input[name = projectRole]").val(data.YourRole);
            $form.find("#projectDuration").val(data.DurationInMonth);
            $('a[data-target=".projectModal"]').click()
        };

        doAjax(parameter);

    });

    $('body').on("click", ".js-edit-workexp", function () {
        var $button = $(this);
        var workExperienceId = $button.data('workexp-id');

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/GetWorkExperience?workExperienceId=' + workExperienceId;
        parameter['successCallbackFunction'] = function (data) {
            var $date = new Date(parseInt((data.FromYear).substr(6)));
            var $fromDate = $date.getFullYear() + '-' + $date.getMonth() + '-' + $date.getDate();

            $date = new Date(parseInt((data.ToYear).substr(6)));
            var $toDate = $date.getFullYear() + '-' + $date.getMonth() + '-' + $date.getDate();

            var $form = $('.workExp-form');
            $form.find('.js-work-experience-id').val(data.ExpId);
            $form.find('input[name = organization]').val(data.Organization);
            $form.find('input[name = designation]').val(data.Designation);
            $form.find("input[name = fromDate]").val($fromDate);
            $form.find("input[name = toDate]").val($toDate);
            $('a[data-target=".workExperienceModal"]').click()
        };

        doAjax(parameter);

    });

    //$('.js-template, .js-edit-resume').on('click', function () {
    //    var $button = $(this);

    //    $.ajax({
    //        url: "/Resume/GetTemplateDetails",
    //        type: "GET",
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (response) {
    //            if (response != null) {
    //                currentData = response;
    //                $.each(response.WorkExperience, function (i, item) {
    //                    if (item['ExpId'] != null) {
    //                        fromDate = new Date(parseInt(item['FromYear'].substr(6)));
    //                        toDate = new Date(parseInt(item['ToYear'].substr(6)));
    //                        var workDetails = $('.tWorkexperience').append($('<div class="font-weight-bold">').text(item['Organization'] + " (" + item['Designation'] + ")"),
    //                                                                 $('<div class="bg-light w-50 rounded">').text(fromDate.getFullYear() + " - " + toDate.getFullYear()));

    //                        $('.workexpData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 we-edit" data-workexp-id="' + item['ExpId'] + '"></i><i class="fas fa-trash we-delete" style="color: red;" data-workexp-id="' + item['ExpId'] + '"></i></div>'),
    //                                                 $('<div class="font-weight-bold">').text(item['Organization'] + " (" + item['Designation'] + ")"),
    //                                                 $('<div class="bg-light w-50 rounded">').text(fromDate.getFullYear() + " - " + toDate.getFullYear()));
    //                    }
    //                    //workDetails.html();
    //                });

    //                $.each(response.Project, function (i, item) {
    //                    var projectDetails = $('.tproject').append($('<div class="font-weight-bold">').text(item['ProjectName']),
    //                                                             $('<div class="bg-light rounded">').text(item['ProjectDetails']));
    //                    $('.projectData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 pr-edit" data-project-id="' + item['ProjectID'] + '"></i><i class="fas fa-trash pr-delete" style="color: red;" data-project-id="' + item['ProjectID'] + '"></i></div>'),
    //                                                 $('<div class="font-weight-bold">').text(item['ProjectName']),
    //                                                 $('<div class="bg-light rounded">').text(item['ProjectDetails']));
    //                });

    //                $.each(response.Skill, function (i, item) {
    //                    if (item['SkillID'] != null) {
    //                        var skillDetails = $('.tskill').append($('<div class="font-weight-bold">').text(item['SkillName']));
    //                        $('.skillData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 sk-edit" data-skill-id="' + item['SkillID'] + '"></i><i class="fas fa-trash sk-delete" style="color: red;" data-skill-id="' + item['SkillID'] + '"></i></div>'),
    //                                               $('<div class="font-weight-bold">').text(item['SkillName']));
    //                    }
    //                });

    //                $.each(response.Education, function (i, item) {
    //                    if (item['EducationLevel'] != null) {
    //                        var educationDetails = $('.teducation').append($('<div class="font-weight-bold">').text(item['EducationLevel']),
    //                                                                       $('<div class="bg-light rounded">').text("Scored: " + item['Score']),
    //                                                                       $('<div class="bg-light rounded">').text("Y.O.P: " + item['YearOfPassing']));
    //                        //-------Data Visible in Edit Page-------
    //                        $('.educationData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 edu-edit" data-education-id="' + item['EduID'] + '"></i><i class="fas fa-trash edu-delete" style="color: red;" data-education-id="' + item['EduID'] + '"></i></div>'),
    //                                       $('<div class="font-weight-bold">').text(item['EducationLevel']),
    //                                       $('<div>').text("Scored: " + item['Score']),
    //                                       $('<div>').text("Year of Passing: " + item['YearOfPassing']),
    //                                       $('<div>').text("Stream: " + item['Stream']));
    //                    }
    //                });

    //                $.each(response.Language, function (i, item) {
    //                    if (item['LanguageName'] != null) {
    //                        var languageKnown = $('.tlanguage').append($('<div class="bg-light rounded">').text(item['LanguageName']));
    //                        //-----Data Visible in Edit Page------------
    //                        $('.languageData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 lang-edit" data-language-id="' + item['LanguageID'] + '"></i><i class="fas fa-trash lang-delete" style="color: red;" data-language-id="' + item['LanguageID'] + '"></i></div>'),
    //                                                     $('<div class="bg-light font-weight-bold rounded">').text(item['LanguageName']));
    //                    }
    //                });

    //                $('.tName').text(response['FirstName'] + " " + response['LastName']);
    //                $('.tEmail').text(response['Email']);
    //                $('.tPhone').text(response['PhoneNumber']);
    //                $('.tResume').text(response['ResumeName']);
    //                $('.tSummary').text(response['Summary']);
    //                //---Data visible in Edit Page
    //                $('.summaryData').append($('<button class="far fa-edit float-right su-edit" data-summary-id="' + response['UserID'] + '"></button>'),
    //                                     $('<div class="font-weight-bold">').text(response['ResumeName']),
    //                                     $('<div>').text(response['Summary']));

    //            }

    //            else {
    //                alert(response.responseText);
    //            }
    //        },
    //        error: function (response) {
    //            alert(response.responseText);
    //        }
    //    });

    //    //if ($button.hasClass('js-template')) {

    //    //    $('.render-partial-view').load("/Resume/Template");
    //    //}
    //    //else if ($button.hasClass("js-edit-resume")) {
    //    //    $('.render-partial-view').load("/Resume/Edit", function () {
    //    //        EditSectionScripts();
    //    //    });
    //    //}

    //    return false;
    //});

    /*              Delete Buttons        */

    $('body').on('click', '.js-delete-education', function () {
        var $button = $(this);
        var id = $button.data('education-id');

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/DeleteEducation?id=' + id;
        parameter['requestType'] = 'DELETE';
        parameter['dataType'] = 'text';
        parameter['successCallbackFunction'] = function (data) {
            $button.parents('.text-secondary').remove();
        };

        confirmDelete(function (result) {
            if (result) {
                doAjax(parameter);
            }
        })
    });

    $('body').on("click", ".js-delete-workexp", function () {
        var $button = $(this);
        var id = $button.data('workexp-id');

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/DeleteWorkExperience?id=' + id;
        parameter['requestType'] = 'DELETE';
        parameter['dataType'] = 'text';
        parameter['successCallbackFunction'] = function (data) {
            $button.parents('.row').remove();
        };

        confirmDelete(function (result) {
            if (result) {
                doAjax(parameter);
            }
        })
    });

    $('body').on("click", ".js-delete-project", function () {
        var $button = $(this);
        var id = $button.data('project-id');

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/DeleteProject?id=' + id;
        parameter['requestType'] = 'DELETE';
        parameter['dataType'] = 'text';
        parameter['successCallbackFunction'] = function (data) {
            $button.parents('.row').remove();
        };

        confirmDelete(function (result) {
            if (result) {
                doAjax(parameter);
            }
        })
    });

    $('body').on("click", ".js-delete-language", function () {
        var $button = $(this);
        var id = $button.data('language-id');

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/DeleteLanguage?id=' + id;
        parameter['requestType'] = 'DELETE';
        parameter['dataType'] = 'text';
        parameter['successCallbackFunction'] = function (data) {
            $button.parents('span').remove();
        };

        confirmDelete(function (result) {
            if (result) {
                doAjax(parameter);
            }
        })
    });

    $('body').on("click", ".js-delete-skill", function () {
        var $button = $(this);
        var id = $button.data('skill-id');

        var parameter = $.extend({}, doAjax_parameter_default);
        parameter['url'] = '/EditResume/DeleteSkill?id=' + id;
        parameter['requestType'] = 'DELETE';
        parameter['dataType'] = 'text';
        parameter['successCallbackFunction'] = function (data) {
            $button.parents('span').remove();
        };

        confirmDelete(function (result) {
            if (result) {
                doAjax(parameter);
            }
        })
    });

    function confirmDelete(callback) {
        bootbox.confirm({
            message: "Do you really want to delete ? This cannot be undone.",
            buttons: {
                cancel: {
                    label: '<i class="fa fa-times text-danger"></i> Cancel'
                },
                confirm: {
                    label: '<i class="fa fa-check"></i> Confirm'

                }
            },
            callback: function (result) {
                callback(result);
            }
        });
    }
}

String.prototype.endsWith = function (suffix) {
    return this.indexOf(suffix, this.length - suffix.length) !== -1;
};

var doAjax_parameter_default = {
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


function doAjax(doAjax_parameter) {

    var url = doAjax_parameter['url'];
    var requestType = doAjax_parameter['requestType'];
    var contentType = doAjax_parameter['contentType'];
    var dataType = doAjax_parameter['dataType'];
    var data = doAjax_parameter['data'];
    var beforeSendCallbackFunction = doAjax_parameter['beforeSendCallbackFunction'];
    var successCallbackFunction = doAjax_parameter['successCallbackFunction'];
    var completeCallbackFunction = doAjax_parameter['completeCallbackFunction'];
    var errorCallBackFunction = doAjax_parameter['errorCallBackFunction'];

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