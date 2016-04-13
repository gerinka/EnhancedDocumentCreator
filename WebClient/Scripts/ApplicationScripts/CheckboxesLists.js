$(document).ready(function() {
    $('.collapse').collapse('hide').on('hide.bs.collapse', function() {
        console.log(this);
    });

    $('#topic1 a input[type=checkbox]').on('click', function(e) {
        e.stopPropagation();
        if (!this.checked) {
            $('#collapseOne').removeClass("collapse");
            $('#collapseOne').addClass("in");
        }
    });

    $('#collapseOne').on('show.bs.collapse', function(e) {
        if (!$('#topic1 a input[type=checkbox]').is(':checked')) {
            return false;
        }
    });

    $(':checkbox').prop('checked', true);
});