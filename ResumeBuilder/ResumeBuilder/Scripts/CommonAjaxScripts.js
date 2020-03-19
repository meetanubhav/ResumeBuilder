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

//------------------------ CODE BY BHABANI-------------------------------------
    $('.js-template').on("click", function () {

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
                        if(item.EducationLevel != null)
                            var educationDetails = $('.teducation').append($('<div class="font-weight-bold">').text(item.EducationLevel),
                                                                           $('<div class="bg-light rounded">').text("Scored "+item.CGPAorPercentage),
                                                                           $('<div class="bg-light rounded">').text(item.YearOfPassing));
                        if (item.LanguageName != null)
                            var languageKnown = $('.tlanguage').append($('<div class="bg-light rounded">').text(item.LanguageName));
                    });

                    $('.tName').text(response[5].FirstName +" "+ response[5].LastName);
                    $('.tEmail').text(response[5].Email);
                    $('.tPhone').text(response[5].PhoneNumber);
                    $('.tResume').text(response[5].ResumeName);
                    $('.tSummary').text(response[5].Summary);
                    $('#test').text(response.Skill + " | Rating: " + response.Rating);   
                }
                else {
                    alert(response.responseText);
                }
            }, 
            error: function (response) {
                alert(response.responseText);
            }
        });
        $('.js-template').show();

        return false;
    });

    $('.js-edit').on("click", function () {
        $.ajax({
            url: "/Resume/GetTemplateDetails",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('.summaryData').append($('<button class="far fa-edit float-right su-edit clickable" data-summary-id="' + response[5].UserID + '"></button>'),
                                         $('<div class="font-weight-bold">').text(response[5].ResumeName),
                                         $('<div>').text(response[5].Summary));

                $.each(response, function (i, item) {
                    if(item.EducationLevel != null) 
                        $('.educationData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 edu-edit" data-education-id="' + item.EduID + '"></i><i class="fas fa-trash edu-delete" data-skill-id="' + item.EduID + '"></i></div>'),
                                           $('<div class="font-weight-bold">').text(item.EducationLevel),
                                           $('<div>').text("Scored: " + item.Score));

                    if (item.Organization != null) {
                        fromDate = new Date(parseInt(item.FromYear.substr(6)));
                        toDate = new Date(parseInt(item.ToYear.substr(6)));
                        $('.workexpData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 we-edit" data-workexp-id="' + item.ExpId + '"></i><i class="fas fa-trash we-delete" data-skill-id="' + item.ExpId + '"></i></div>'),
                                                 $('<div class="font-weight-bold">').text(item.Organization + " (" + item.Designation + ")"),
                                                 $('<div class="bg-light w-50 rounded">').text(fromDate.getFullYear() + " - " + toDate.getFullYear()));
                    }

                    if(item.ProjectID != null)
                        $('.projectData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 pr-edit" data-project-id="' + item.ProjectID + '"></i><i class="fas fa-trash pr-delete" data-skill-id="' + item.ProjectID + '"></i></div>'),
                                                 $('<div class="font-weight-bold">').text(item.ProjectName),
                                                 $('<div class="bg-light rounded">').text(item.ProjectDetails));

                    if (item.LanguageName != null)
                        $('.languageData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 lan-edit" data-language-id="' + item.LanguageID + '"></i><i class="fas fa-trash lan-delete" data-skill-id="' + item.LanguageID + '"></i></div>'),
                                                  $('<div class="bg-light rounded">').text(item.LanguageName));

                    if (item.Skill != null)
                        $('.skillData').append($('<div class="display-inline float-right"><i class="far fa-edit mr-2 sk-edit" data-skill-id="' + item.UserSkillID + '"></i><i class="fas fa-trash sk-delete" data-skill-id="' + item.UserSkillID + '"></i></div>'),
                                               $('<div class="font-weight-bold">').text(item.Skill),
                                               $('<div class="bg-light rounded rate">').text(item.Rating).append($("<i class='fas fa-star' style='color: #e6185e;'></i>")));
                });
                
                                         
            }
        });
    });

    $('body').on("click", ".su-edit", function () {
        $('a')[5].click();

    });

    $('body').on("click", ".edu-edit", function () {

        $('a')[6].click();

    });

    $('body').on("click", ".we-edit", function () {

        $('a')[7].click();

    });

    $('body').on("click", ".pr-edit", function () {

        $('a')[8].click();

    });

    $('body').on("click", ".lang-edit", function () {

        $('a')[9].click();

    });

    $('body').on("click", ".sk-edit", function () {

        $('a')[10].click();

    });

//------------------------END CODE OF BHABANI---------------------------------------------------

}