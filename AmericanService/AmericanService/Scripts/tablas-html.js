jQuery(function ($) {
    $('.table').footable();

    var prm = Sys.WebForms.PageRequestManager.getInstance();
    if (prm != null) {
        prm.add_endRequest(function () {
            $(document).ready(function () {
                $('table').footable();
            });
        });
    }

});

jQuery(function ($) {
    $('.table').footable();
});