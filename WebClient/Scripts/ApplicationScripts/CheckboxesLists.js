$('.collapse').collapse();
$('#topic1 a input[type=checkbox]').on('click', function (e) {
    e.stopPropagation();
})
$('#collapseOne').on('show.bs.collapse', function (e) {
    if (!$('#topic1 a input[type=checkbox]').is(':checked')) {
        return false;
    }
});