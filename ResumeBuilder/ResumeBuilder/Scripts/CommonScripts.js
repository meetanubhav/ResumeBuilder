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


    $('body').on("click", "a.viewBtn", function () {
        var templateId = $(this).data("template-id");
        $('.render-partial-view').load("/Template/Template" + templateId);
    });

    $('body').on("click", ".download-template", function () {
        // Define variables
        var
         form = $(this).next(),
         cache_width = form.width(),
         cache_height = form.height(),
         a4 = [595.28, 841.89]; // for a5 size paper width and height

        if (form != null) {
            // Scroll screen
            $('body').scrollTop(0);
            // Call function createPDF
            createPDF();
        }
        //create pdf
        function createPDF() {
            if (cache_height > 600)
                cache_height = 600;

            // Call create canvas function
            getCanvas().then(function (canvas) {
                var
                 img = canvas.toDataURL("image/png"),
                 doc = new jsPDF({
                     unit: 'px',
                     format: 'a4'
                 });
                doc.setFont("arial", "bold");
                doc.addImage(img, 'JPEG', 20, 20, 420, cache_height);

                doc.save('YourResume.pdf');
                form.width(cache_width);
            });
        }

        // create canvas object
        function getCanvas() {

            form.width((a4[0] * 1.33333)).css('max-width', 'none');
            return html2canvas(form, {
                imageTimeout: 3000,
                removeContainer: true
            });
        }

    });

});
