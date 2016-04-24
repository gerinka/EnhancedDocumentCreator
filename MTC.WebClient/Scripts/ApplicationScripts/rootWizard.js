$(document).ready(function () {
    $('#rootwizard').bootstrapWizard({
        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;
            var $percent = ($current / $total) * 100;
            $('#rootwizard .progress-bar').css({ width: $percent + '%' });
            $(".nav-pills li").addClass("invisible");
            $(".nav-pills li.active").removeClass("invisible");
        }
    });
    var minDate = new Date();
    minDate.setDate(minDate.getDate() + 7);
    $('#deadline').datetimepicker({
        locale: 'bg',
        format: 'DD MMMM YYYY',
        minDate: minDate
    });

    $('.dropdown-menu a').on('click', function() {
        if (!$(this).parent().hasClass("disabled")) {
            $('.dropdown-toggle').html($(this).html() + '<span class="caret"></span>');
        }
    });
});