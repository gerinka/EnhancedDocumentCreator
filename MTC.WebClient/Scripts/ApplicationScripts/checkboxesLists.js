$(document).ready(function() {
    $('#collapseTopic1').collapse('hide').on('hide.bs.collapse', function () {
        console.log(this);
    });

    $('div.active input[type=checkbox].main-topic').on('click', function (e) {
        e.stopPropagation();
        if (!this.checked) {
            $('#collapseTopic1').removeClass("collapse");
        } else {
            $('#collapseTopic1').addClass("collapse");
        }
    });

    $('#collapseTopic1').on('show.bs.collapse', function (e) {
        if (!$('div.active input[type=checkbox].main-topic').is(':checked')) {
            return false;
        }
    });

    $(':checkbox').prop('checked', true);
    $(".main-topic").change(function () {
        if (this.checked) {
            console.log("fsdfs");
        }
    });
});
function changeState(el) {
    if (el.readOnly) el.checked = el.readOnly = false;
    else if (!el.checked) el.readOnly = el.indeterminate = true;
}