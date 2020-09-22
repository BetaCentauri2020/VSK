;(function ($) {

    "use strict";
    $(document).ready(function () {


        /*------------ Start site menu  ------------*/

        // Start sticky header
        $(window).on('scroll', function () {
            if ($(window).scrollTop() >= 150) {
                $('#sticky-header').addClass('sticky-menu');
            } else {
                $('#sticky-header').removeClass('sticky-menu');
            }
        });

        $("#ation-menu").metisMenu();

        $('.scrollbar-macosx').scrollbar();

        $('.menu-toggler').on('click', function () {
            $('.ation-sidebar').toggleClass('ation-sidebar-hide');
            $('.content-wrapper').toggleClass('content-wrapper-expend');
            $('footer').toggleClass('content-wrapper-expend');
        });
        $('.menu-close').on('click',function(){
            $('.ation-sidebar').removeClass('ation-sidebar-hide');
        });


        if ($('#defaultCountdown').length) {
            $('#defaultCountdown').countdown({until: '+15d +11h'});
        }

        if ($('#calendar').length) {
            $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: '2020-07-11',
                editable: true,
                eventLimit: true,
                eventClick: function (event) {
                    if (event.url) {
                        $.magnificPopup.open({
                            items: {
                                iframe: event.url,
                                type: 'iframe'
                            }
                        });
                    }
                }
            });
        }
    })

    /*scrollbar*/
    $('.scrollbar-outer').scrollbar();


})(jQuery);
