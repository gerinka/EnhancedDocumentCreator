$(document).ready(function () {

    function init() {
        var index = parseInt($(".panel-heading h3.active")[0].dataset.section);
        var total = $(".panel-heading h3").length;
        var percent = Math.round((index / total) * 100);
        $('.progress-bar').attr('aria-valuenow', percent).css('width', percent + '%').html(percent + '%');
        if (index == 1) {
            $(".previous").addClass("hidden");
        } else if (index == total) {
            $(".next").addClass("hidden");
        }

    };

    init();
    $(".next").on("click", function() {
        var index = parseInt($(".panel-heading h3.active")[0].dataset.section);
        var total = $(".panel-heading h3").length;
        if (index + 1 <= total) {
            var currentElement = $(".panel-heading h3")[index - 1];
            $(".panel-heading").find(currentElement).removeClass("active");
            $(".panel-heading").find(currentElement).addClass("hidden");

            var nextElement = $(".panel-heading h3")[index];
            $(".panel-heading").find(nextElement).removeClass("hidden");
            $(".panel-heading").find(nextElement).addClass("active");

            $(".form-group").filter(function () {
                if (parseInt($(this).data("section")) == index) {
                    $(this).addClass("hidden");
                    $(this).removeClass("active");
                } else if (parseInt($(this).data("section")) == index + 1) {
                    $(this).addClass("active");
                    $(this).removeClass("hidden");
                }
            });
            var futureIndex = index + 1;
            var percent = Math.round((futureIndex / total) * 100);
            $('.progress-bar').attr('aria-valuenow', percent).css('width', percent + '%').html(percent + '%');

            if (futureIndex == total) {
                $(".next").addClass("hidden");
            } else if (futureIndex - 1 > 0) {
                $(".previous").removeClass("hidden");
            }
        }
    });

    $(".previous").on("click", function () {
        var index = parseInt($(".panel-heading h3.active")[0].dataset.section);
        var total = $(".panel-heading h3").length;
        if (index - 1 > 0) {
            var currentElement = $(".panel-heading h3")[index - 1];
            $(".panel-heading").find(currentElement).removeClass("active");
            $(".panel-heading").find(currentElement).addClass("hidden");

            var previousElement = $(".panel-heading h3")[index - 2];
            $(".panel-heading").find(previousElement).removeClass("hidden");
            $(".panel-heading").find(previousElement).addClass("active");

            $(".form-group").filter(function () {
                if (parseInt($(this).data("section")) == index) {
                    $(this).addClass("hidden");
                    $(this).removeClass("active");
                } else if (parseInt($(this).data("section")) == index - 1) {
                    $(this).addClass("active");
                    $(this).removeClass("hidden");
                }
            });

            var futureIndex = index - 1;

            var percent = Math.round((futureIndex / total) * 100);
            $('.progress-bar').attr('aria-valuenow', percent).css('width', percent + '%').html(percent + '%');
            if (futureIndex == 1) {
                $(".previous").addClass("hidden");
            } else if (futureIndex < total) {
                $(".next").removeClass("hidden");
            }
        }
    });
});