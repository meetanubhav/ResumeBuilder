function AjaxScripts() {
    //Ajax Script for edit section view
    $('body').on("click", '.save-basic-info', function (e) {
        var userData = new Object();
        {
            userData.userID = $("#userId").val();
            userData.firstName = $("[name = firstName]").val();
            userData.lastName = $("[name = lastName]").val();
            userData.email = $("[name = email]").val();
            userData.PhoneNumber = $("[name = primaryPhoneNumber]").val();
            userData.AlternatePhoneNumber = $("[name = altPhoneNumber]").val();
        }

        ajaxFunc('/EditResume/AddBasicInformation', userData, 'success');

        return false;
    });

    var ajaxFunc = function (url, formData, message) {
        $.ajax({
            url: url,
            type: 'POST',
            data: formData,
            success: function (response) {
                //$('.show-content').html(response);
            },
            failure: function (response) {
            }
        });
    }
}
//String.prototype.endsWith = function (suffix) {
//    return this.indexOf(suffix, this.length - suffix.length) !== -1;
//};

//var doAjax_params_default = {
//    'url': null,
//    'requestType': "GET",
//    'contentType': 'application/x-www-form-urlencoded; charset=UTF-8',
//    'dataType': 'json',
//    'data': {},
//    'beforeSendCallbackFunction': null,
//    'successCallbackFunction': null,
//    'completeCallbackFunction': null,
//    'errorCallBackFunction': null,
//};


//function doAjax(doAjax_params) {

//    var url = doAjax_params['url'];
//    var requestType = doAjax_params['requestType'];
//    var contentType = doAjax_params['contentType'];
//    var dataType = doAjax_params['dataType'];
//    var data = doAjax_params['data'];
//    var beforeSendCallbackFunction = doAjax_params['beforeSendCallbackFunction'];
//    var successCallbackFunction = doAjax_params['successCallbackFunction'];
//    var completeCallbackFunction = doAjax_params['completeCallbackFunction'];
//    var errorCallBackFunction = doAjax_params['errorCallBackFunction'];

//    //make sure that url ends with '/'
//    /*if(!url.endsWith("/")){
//     url = url + "/";
//    }*/

//    $.ajax({
//        url: url,
//        crossDomain: true,
//        type: requestType,
//        contentType: contentType,
//        dataType: dataType,
//        data: data,
//        beforeSend: function (jqXHR, settings) {
//            if (typeof beforeSendCallbackFunction === "function") {
//                beforeSendCallbackFunction();
//            }
//        },
//        success: function (data, textStatus, jqXHR) {
//            if (typeof successCallbackFunction === "function") {
//                successCallbackFunction(data);
//            }
//        },
//        error: function (jqXHR, textStatus, errorThrown) {
//            if (typeof errorCallBackFunction === "function") {
//                errorCallBackFunction(errorThrown);
//            }

//        },
//        complete: function (jqXHR, textStatus) {
//            if (typeof completeCallbackFunction === "function") {
//                completeCallbackFunction();
//            }
//        }
//    });