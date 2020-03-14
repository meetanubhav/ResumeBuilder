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
            url: "/Resume/GetSkillDetails",
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
//------------------------END CODE OF BHABANI---------------------------------------------------

}