﻿//function AjaxScripts() {
//    //Ajax Script for edit section view
//    $('.save-basic-info').on("click", function (e) {
//        var userData = new Object();
//        userData.userID = $("#userId").val();
//        userData.firstName = $("[name = firstName]").val();
//        userData.lastName = $("[name = lastName]").val();
//        userData.email = $("[name = email]").val();
//        userData.contact = $("[name = contact]").val();
//        $.ajax({
//            url: '/Resume/AddBasicInfo',
//            contentType: 'application/html; charset=utf-8',
//            type: 'POST',
//            data: JSON.stringify(userData),
//            success: function (response) {
//                //$('.show-content').html(response);
//                alert("success")
//            },
//            failure: function (response) {
//                alert(status);
//            }
//        })
//        return false;
//    });
//}
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


    var ajaxFunc = function (url, formdata, message) {
        $.ajax({
            url: url,
            method: "POST",
            data: formdata,
            dataType: "json",
            success: function () {
                alert("Sent Successfully")
            }
        });
    }

}