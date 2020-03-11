function AjaxScripts() {
    //Ajax Script for edit section view
    $('.save-basic-info').on("click", function (e) {
        var userData = new Object();
        userData.userID = $("#userId").val();
        userData.firstName = $("[name = firstName]").val();
        userData.lastName = $("[name = lastName]").val();
        userData.email = $("[name = email]").val();
        userData.contact = $("[name = contact]").val();
        $.ajax({
            url: '/Resume/AddBasicInfo',
            contentType: 'application/html; charset=utf-8',
            type: 'POST',
            data: JSON.stringify(userData),
            success: function (response) {
                //$('.show-content').html(response);
                alert("success")
            },
            failure: function (response) {
                alert(status);
            }
        })
        return false;
    });
}