﻿$(document).ready(function () {
    $('.js-edit').on("click", function () {
        $('.render-partial-view').load("/Resume/Edit");
        EditSectionScripts();

        return false;
    });
    
    $('.js-settings').on("click", function () {
        $('.render-partial-view').load("/Resume/Settings");
        return false;
    });
    
    AjaxScripts();
});