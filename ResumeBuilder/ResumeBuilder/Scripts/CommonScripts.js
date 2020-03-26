$(document).ready(function () {
    //$('.js-edit-resume').on("click", function () {
    //    //var userId = parseInt($("#userId").val());
    //    $('.render-partial-view').load("/Resume/Edit");
    //    EditSectionScripts();
    //    return false;
    //});

    $('.js-template').on('click', function () {
        $('.render-partial-view').load("");
    });

    $('.js-public-profile').on('click', function (e) {
        e.preventDefault();
        window.open('/Resume/PublicProfile/'+ $('#userId').val(), '_blank');
    });
    
    $('.js-settings').on('click', function (e) {
        e.preventDefault();
        $('.render-partial-view').load("/Settings/Settings", function () {
            ResumeSettingsScript();
        });
    });

    AjaxScripts();
    //$('body').on("click",'.js-public-profile', function (e) {
    //    e.preventDefault();
    //    window.open('/Resume/PublicProfile/' + $('#userId').val());
    //});
});    
