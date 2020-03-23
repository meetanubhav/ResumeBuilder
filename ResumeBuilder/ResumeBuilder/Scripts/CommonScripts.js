$(document).ready(function () {
    $('.js-edit-resume').on("click", function () {
        $('.render-partial-view').load("/Resume/Edit");
        EditSectionScripts();
        return false;
    });
    
<<<<<<< HEAD
    $('.js-template').on("click", function () {
        $('.render-partial-view').load("/Resume/Template");
    });

    $('.js-public-profile').on("click", function () {
        window.open('/Resume/PublicProfile', '_blank');
    });

    $('.js-settings').on("click", function (e) {
        e.preventDefault();
        $('.render-partial-view').load("/Settings/Settings", function () {
            ResumeSettingsScript();
        });
=======
    $('.js-settings').on("click", function () {
        $('.render-partial-view').load("/Settings/Settings");
        return false;
>>>>>>> parent of 471080a... Merge branch 'master' of https://github.com/meetanubhav/ResumeBuilder
    });

    AjaxScripts();
});