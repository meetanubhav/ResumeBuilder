$(document).ready(function () {
    $('.js-edit').on("click", function () {
        //var userId = parseInt($("#userId").val());
        $('.render-partial-view').load("/Resume/Edit");
        EditSectionScripts();
        return false;
    });

    $('.js-template').on('click', function () {
        $('.render-partial-view').load("");
    });

    $('.js-public-profile').on('click', function () {
        window.open('/Resume/PublicProfile', '_blank');
    });
    
    $('.js-settings').on('click', function (e) {
        e.preventDefault();
        $('.render-partial-view').load("/Settings/Settings", function () {
            ResumeSettingsScript();
        });
    });

    AjaxScripts();
});
