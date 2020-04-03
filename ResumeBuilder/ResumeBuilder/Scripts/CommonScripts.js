$(window).on("load", function () {
    $(".se-pre-con").fadeOut("slow");
});
$(document).ready(function () {

    $('.js-edit-resume').on("click", function () {
        //var userId = parseInt($("#userId").val());
        $('.render-partial-view').load("/Resume/Edit");
        EditSectionScripts();
        return false;
    });
    $('.js-template').on('click', function (e) {
        e.preventDefault();
        $('.render-partial-view').load("/Resume/Template");
    });

    $('.message a').click(function () {
        $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
    });
    $('.js-public-profile').on('click', function (e) {
        e.preventDefault();
        window.open('/Resume/PublicProfile?userId=' + $('#userId').val(), '_blank');
    });

    $('.js-settings').on('click', function (e) {
        e.preventDefault();
        $('.render-partial-view').load("/Settings/Settings", function () {
            ResumeSettingsScript();
        });
    });

    $('.js-search').on('click', function (e) {
        e.preventDefault();
        $('.render-partial-view').load("/Resume/Search", function () {
            //Search section Scripts
            var myDataTable = $('#searchTable').DataTable({
                "ajax": {
                    "url": "/Resume/GetAllUsersData",
                    "type": "GET",
                    "dataSrc": function (d) {
                        return d;
                    }
                },
                "columns": [
                    { "data": "FirstName" },
                    { "data": "LastName" },
                    { "data": "Skills" },
                ]
            });
        });
    });

    AjaxScripts();

    $('body').on("click", "a.viewBtn", function () {
        var templateId = $(this).data("template-id");
        $('.render-partial-view').load("/Template/Template" + templateId);
    });

    $('body').on("hide.bs.modal", '.modal', function () {
        var modal = $(this);
        $(modal.find('input:not(:checkbox):not(:radio)')).val('');
        $(modal.find('input[type=checkbox]')).prop("checked", false);
        $(modal.find('input[type=radio]')).prop("checked", false);
    });

});
