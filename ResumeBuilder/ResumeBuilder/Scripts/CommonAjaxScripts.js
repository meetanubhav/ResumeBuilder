function AjaxScripts() {
    /*              Save Basic Information            */
    $('body').on("click", ".save-basic-info", function (e) {
        e.preventDefault();
        if (checkNull('.basicInfomodal') === 0) {
            //if (checkNull(["input[name = FirstName]", "input[name = LastName]", "input[name = Email]", "input[name = PhoneNumber]", "input[name = AlternatePhoneNumber]"]) === 0) {
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

                hideModal();
            };
            doAjax(parameter);

            return false;
        }
    });

    /*              Save Summary Information            */

    $('body').on("click", ".save-summary-info", function (e) {
        e.preventDefault();
        if (checkNull('.summaryModal') === 0) {
            var userData = {};
            userData.ResumeName = $("input[name = ResumeName]").val();
            userData.Summary = $("textarea[name = Summary]").val();

            var parameter = $.extend({}, doAjax_parameter_default);
            parameter['url'] = '/EditResume/AddSummaryInfo';
            parameter['data'] = userData;
            parameter['requestType'] = 'POST';
            parameter['successCallbackFunction'] = function (userData) {
                $("input[name = ResumeName]").val(userData.ResumeName);
                $("textarea[name = Summary]").val(userData.Summary);

                $(".show-summary-info").text(userData.Summary);
                $(".show-resume-info").text(userData.ResumeName);

                hideModal();

            };
            doAjax(parameter);

            return false;
        }
    });

    /*              Save Education Information            */

    $('body').on("click", ".save-education-info", function (e) {
        e.preventDefault();
        if (checkNull('.educationModal') === 0) {
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
            parameter['dataType'] = null;
            parameter['requestType'] = 'POST';
            parameter['successCallbackFunction'] = function (data) {
                if (data == "Repeatition of data" || data == "Invalid User" || data == "Failed") {
                    $(".alert").show();
                    $(".alert").addClass("alert-success");
                    $('.alert-message').text(data);
                    $(".alert").fadeOut(5000);
                    console.log(data);
                }
                else {
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
                }
                hideModal();

            };
            doAjax(parameter);

            return false;
        }
    });

    /*              Save Skills Information            */

    $('body').on("click", ".save-skill", function (e) {
        e.preventDefault();
        if (checkNull('.skillModal') === 0) {
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
            parameter['dataType'] = null;
            parameter['successCallbackFunction'] = function (data) {
                if (data == "Skill already present") 
                    {
                    $(".alert").show();
                    $(".alert").addClass("alert-warning");
                    $('.alert-message').text(data);
                    $(".alert").fadeOut(5000);

                }
                else {
                    $('.js-skill-details').append('<span class="btn btn-primary ml-1 mt-1"> \
                    '+ data.SkillName + ' \
                <i class="fa fa-times js-delete-skill text-danger" data-skill-id="'+ data.SkillID + '"> </i> \
                    </span>');
                }

                hideModal();

            };
            doAjax(parameter);

            return false;
        }
    });

    /*              Save Project Information            */

    $('body').on("click", ".save-project", function (e) {
        e.preventDefault();
        if (checkNull('.projectModal') === 0) {
            var id = $('.js-project-id').val();
            var $button = $('button [data-project-id="' + id + '"]');

            var userData = new Object();
            {
                userData.ProjectID = $('.js-project-id').val();
                userData.DurationInMonth = $("#projectDuration option:selected").val();
                userData.ProjectName = $("input[name = projectName]").val();
                userData.ProjectDetails = $("textarea[name = projectDetails]").val();
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

                hideModal();

            };
            doAjax(parameter);

            return false;
        }
    });

    /*              Save Work Experience Information            */

    $('body').on("click", ".save-workExp", function (e) {
        e.preventDefault();
        //if ($('#currentWork').is(':checked') == true) {
        //    $("input[name = toDate]").val("2000-01-01");
        //}
        if (checkNull('.workExperienceModal') === 0) {
            var id = $('.js-work-experience-id').val();
            var $button = $('button [data-workexp-id="' + id + '"]');

            var userData = new Object();
            {
                userData.ExpId = $('.js-work-experience-id').val();
                userData.Organization = $("input[name = organization]").val();
                userData.Designation = $("input[name = designation]").val();
                userData.FromYear = $("input[name = fromDate]").val();
                userData.ToYear = $("input[name = toDate]").val();
                userData.CurrentlyWorking = $('#currentWork').is(':checked');
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

                hideModal();

            };
            doAjax(parameter);

            return false;
        }
    });

    /*              Save Language Information            */

    $('body').on("click", ".save-language", function (e) {
        e.preventDefault();
        if (checkNull('.languageModal') === 0) {
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
            parameter['dataType'] = null;
            parameter['successCallbackFunction'] = function (data) {
                if (data == "Language already present") {
                    $(".alert").show();
                    $(".alert").addClass("alert-warning");
                    $('.alert-message').text(data);
                    $(".alert").fadeOut(5000);
                }
                else {
                    $('.js-language-details').append('<span class="btn btn-primary ml-1 mt-1"> \
                    ' + data.LanguageName + ' \
                    <i class="fa fa-times js-delete-language text-danger" data-language-id="'+ data.LanguageID + '"> </i> \
                    </span>');
                }
                hideModal();

            }
            doAjax(parameter);

            return false;
        }
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

        var parameter  = $.extend({}, doAjax_parameter_default);
        parameter ['url'] = '/Settings/AddOrUpdateSettings';
        parameter ['data'] = formDetails;
        parameter ['requestType'] = 'POST';
        parameter ['dataType'] = 'text';
        parameter ['successCallbackFunction'] = function (data) {
            if (data == 'success') {
                $(".alert").show();
                $(".alert").addClass("alert-success");
                $('.alert-message').text("Settings updated successfully");
                $(".alert").fadeOut(5000);
            }
            else {
                $(".alert").show();
                $(".alert").addClass("alert-danger");
                $('.alert-message').text("Failed to update settings");
                $(".alert").fadeOut(5000);
            }
        };

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
            $('a[data-target=".educationModal"]').click();
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
            $form.find('textarea[name = projectDetails]').val(data.projectDetails);
            $form.find("input[name = projectRole]").val(data.YourRole);
            $form.find("#projectDuration").val(data.DurationInMonth);
            $('a[data-target=".projectModal"]').click();
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
    $("small").text('');
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
                
                if (requestType == "POST") {
                    $(".alert").show();
                    $(".alert").addClass("alert-success");
                    $('.alert-message').text("Saved Succesfully!");
                    $(".alert").fadeOut(5000);
                }
                if (requestType == "DELETE") {
                    $(".alert").show();
                    $(".alert").addClass("alert-primary");
                    $('.alert-message').text("Deleted Succesfully!");
                    $(".alert").fadeOut(5000);
                }
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (typeof errorCallBackFunction === "function") {
                errorCallBackFunction(errorThrown);
            }
            $('.modal').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
            $(".alert").show();
            $(".alert").addClass("alert-danger");
            $('.alert-message').text("Error could not save.");
            $(".alert").fadeOut(5000);
        },
        complete: function (jqXHR, textStatus) {
            if (typeof completeCallbackFunction === "function") {
                completeCallbackFunction();
            }
        }
    });
}
function checkNull(divName) {
    $("small").text('');
    var counter = 0;
    //for (var i = 0; i < divName.length; i++) {
    //    if ($(divName[i]).val() == "") {
    //        $(this).next("small").text('Empty Field');
    //                counter += 1;
    //    }
    //}
    $(divName).find("input[type = 'text']").each(function () {
        if (this.value == "") {
            $("this").css("border-color", "red");
            $(this).next("small").text('Empty Field');
            counter += 1;
        }
    });
    $(divName).find("textarea").each(function () {
        if (this.value == "") {
            $("this").css("border-color", "red");
            $(this).next("small").text('Empty Field');
            counter += 1;
        }
    });
    $(divName).find("select").each(function () {
        if (this.value == 0) {
            $("this").css("border-color", "red");
            $(this).next("small").text('Empty Field');
            counter += 1;
        }
    });
    $(divName).find("input[type = 'date']").each(function () {
        if (this.value == "") {
            $("this").css("border-color", "red");
            $(this).next("small").text('Empty Field');
            counter += 1;
        }
        var dateObj = new Date();
        if (parseInt(this.value.slice(0, 4)) >= dateObj.getFullYear()) {
            if (parseInt(this.value.slice(5, 7)) >= (dateObj.getMonth() + 1)) {
                if (parseInt(this.value.slice(8, 10)) > dateObj.getDate()) {
                    $("this").css("border-color", "red");
                    $(this).next("small").text("Date is larger than Today's date");
                    counter += 1;
                }
            }
        }
    });

    return counter
}

var hideModal = function () {
    $('.modal').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
};