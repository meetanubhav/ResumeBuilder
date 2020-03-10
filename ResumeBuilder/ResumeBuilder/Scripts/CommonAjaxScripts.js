function AjaxScripts() {
    //Ajax Script for edit section view
    $('.save-basic-info').on("click", function (e) {
        $.ajax({
            url: '/Resume/Edit',
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            dataType: 'html',
            success: function (response) {
                $('.show-content').html(response);
            },
            failure: function (response) {
                alert(status);
            }
        })
        return false;
    });
}