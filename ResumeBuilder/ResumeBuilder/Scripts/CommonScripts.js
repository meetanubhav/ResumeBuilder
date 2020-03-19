$(document).ready(function () {
    $('.js-edit').on("click", function () {
        //var userId = parseInt($("#userId").val());
        $('.render-partial-view').load("/Resume/Edit");
        EditSectionScripts();
        return false;
    });
    
    $('.js-settings').on("click", function (e) {
        e.preventDefault();
        $('.render-partial-view').load("/Settings/Settings", function () {
            ResumeSettingsScript();
        });
        //return false;

    AjaxScripts();
});