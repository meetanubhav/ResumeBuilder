$(document).ready(function () {
    //$('.js-edit-resume').on("click", function () {
    //    $('.render-partial-view').load("/Resume/Edit", function ()
    //    {
    //        EditSectionScripts();
    //    });
    //    return false;
    //});
    
    //$('.js-template').on("click", function () {
    //    $('.render-partial-view').load("/Resume/Template");
    //});

    $('.js-public-profile').on("click", function () {
        window.open('/Resume/PublicProfile', '_blank');
    });

    $('.js-settings').on("click", function (e) {
        e.preventDefault();
        $('.render-partial-view').load("/Settings/Settings", function () {
            ResumeSettingsScript();
        });
    });

    AjaxScripts();
});