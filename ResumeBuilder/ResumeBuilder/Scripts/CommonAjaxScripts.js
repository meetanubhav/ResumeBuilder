function AjaxScripts() {

    //Ajax Script by bhabani
    $('.save-basic-info').on("click", function () {

        var formData = $('.basic-info-form').serialize();
        $.ajax({
            url: "/Resume/AddBasicInfo",
            method: "POST",
            data: formData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Data Saved Successfully");
            }
        });
        $(this).parent().next().next().show(300);
    });

    //$('.btn-save').on("click", function () {

    //    var formData = $(this).parent().serialize();
    //    $.ajax({
    //        url: "/Resume/AddBasicInfo",
    //        method: "POST",
    //        data: formData,
    //        dataType: "json",
    //        success: function (data) {
    //            alert(data);
    //        }
    //    });
    //    $(this).parent().parent().next().next().show(300);
    //});
}