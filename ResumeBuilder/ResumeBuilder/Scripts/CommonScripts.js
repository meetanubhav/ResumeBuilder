$(document).ready(function () {
    $('.js-edit').on("click", function () {
        var userId = parseInt($("#userId").val());
        $('.render-partial-view').load("/Resume/Edit", { userId: userId });
        EditSectionScripts();

        return false;
    });
    
    $('.js-settings').on("click", function () {
        $('.render-partial-view').load("/Resume/Settings");
        return false;
    });
    
    AjaxScripts();
});