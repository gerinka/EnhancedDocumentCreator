$(document).ready(function () {

    function init() {
        var index = parseInt($(".panel-heading h3.active")[0].dataset.section);
        var total = $(".panel-heading h3:not(.notselected)").length;
        var percent = 9;
        $('.progress-bar').attr('aria-valuenow', percent).css('width', percent + '%').html(percent + '%');
        if (index == 1) {
            $(".previous").addClass("hidden");
        } else if (index == total) {
            $(".next").addClass("hidden");
        }

        $("input:checkbox").prop('checked', true);
    };

    init();
    $(".next").on("click", function () {
        var selectedTemplate = $('#templateDropdown');
        if (selectedTemplate.val().length > 0) {
            var index = parseInt($(".panel-heading h3.active")[0].dataset.section);
            var total = $(".panel-heading h3:not(.notselected)").length;
            if (index + 1 <= total) {
                var currentElement = $(".panel-heading h3:not(.notselected)")[index - 1];
                $(".panel-heading").find(currentElement).removeClass("active");
                $(".panel-heading").find(currentElement).addClass("hidden");

                var nextElement = $(".panel-heading h3:not(.notselected)")[index];
                $(".panel-heading").find(nextElement).removeClass("hidden");
                $(".panel-heading").find(nextElement).addClass("active");

                $(".form-group:not(.notselected)").filter(function() {
                    if (parseInt($(this)[0].dataset.section) == index) {
                        $(this).addClass("hidden");
                        $(this).removeClass("active");
                    } else if (parseInt($(this)[0].dataset.section) == index + 1) {
                        $(this).addClass("active");
                        $(this).removeClass("hidden");
                    }
                });
                var futureIndex = index + 1;
                var percent = Math.round((futureIndex / total) * 100);
                $('.progress-bar').attr('aria-valuenow', percent).css('width', percent + '%').html(percent + '%');

                if (futureIndex == total) {
                    $(".next").addClass("hidden");
                    $("#summaryTitle").text($("#Topic").val());
                    $("#summaryDeadline").text($("#Deadline").val());
                    var selectedCheckBoxes = $('input:checkbox.sections').each(function () {
                        var sThisVal = (this.checked ? $(this).val() : "");
                    });
                    $("#summaryCountSections").text(selectedCheckBoxes.length);
                } else if (futureIndex - 1 > 0) {
                    $(".previous").removeClass("hidden");
                }
            }
        } else {
            $("#templateDropdownError").text("Изберете шаблон!");
        }
    });

    $(".previous").on("click", function () {
        var index = parseInt($(".panel-heading h3.active")[0].dataset.section);
        var total = $(".panel-heading h3:not(.notselected)").length;
        if (index - 1 > 0) {
            var currentElement = $(".panel-heading h3:not(.notselected)")[index - 1];
            $(".panel-heading").find(currentElement).removeClass("active");
            $(".panel-heading").find(currentElement).addClass("hidden");

            var previousElement = $(".panel-heading h3:not(.notselected)")[index - 2];
            $(".panel-heading").find(previousElement).removeClass("hidden");
            $(".panel-heading").find(previousElement).addClass("active");

            $(".form-group:not(.notselected)").filter(function () {
                if (parseInt($(this)[0].dataset.section) == index) {
                    $(this).addClass("hidden");
                    $(this).removeClass("active");
                } else if (parseInt($(this)[0].dataset.section) == index - 1) {
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

function PopulateSectionList() {
    var templateId = $('#templateDropdown').val();
    if (templateId.length > 0) {
        $("#templateDropdownError").text("");
        $('[data-template]').addClass("notselected");
        var sections = $(".notselected");
        var j = 2;

        for (var i = 0; i < sections.length; i++) {
            if (parseInt(sections[i].dataset.template) == templateId) {
                if ($(".panel-heading").find(sections[i]).length > 0) {
                    $(".panel-heading").find(sections[i]).removeClass("notselected");
                    j++;
                } else {
                    $(".panel-body").find(sections[i]).removeClass("notselected");
                }
            }
        }
        $('#summary')[0].dataset.section = j;
        $('#summaryHeading')[0].dataset.section = j;
    }
}