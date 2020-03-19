function ResumeSettingsScript() {
    
    $('.setting-form input').each(function (i, e) {

        if ($(e).data().val == 'True') {
            $(e)[0].checked = true;
        }
    });
}

