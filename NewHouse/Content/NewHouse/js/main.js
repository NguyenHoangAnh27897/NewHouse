(function ($) {
    "use strict";


    var $body = $("body"),
            $window = $(window);


    /*===========================================preload===========================================*/


    $(window).on('load', function () {
        // Animate loader off screen
        $(".se-pre-con").fadeOut("slow");
        ;
    });

    /*===========================================counter-up===========================================*/

    $('.Count').each(function () {
        "use strict";
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text()
        }, {
            duration: 15000,
            easing: 'swing',
            step: function (now) {
                $(this).text(Math.ceil(now));
            }
        });
    });



    /*============================= Navigation Section ==============================*/



    $window.on('scroll', function () {
        if ($(".navbar").offset().top > 50) {
            $(".navbar-default").addClass("small");
        } else {
            $(".navbar-default").removeClass("small");
        }
    });


    /*============================= Smoothscroll js ==============================*/

    $('.navbar-default').on('click', 'a', function (event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top - 1
        }, 1000);
        event.preventDefault();
    });


    /*====================================== jquery scroll spy ========================================*/

    $body.scrollspy({
        target: ".navbar-collapse",
        offset: 15

    });

    /*============================================carousel==========================================*/

    $('.carousel').carousel({
        interval: 5000
    });

    /*====================================== COLOR SCHEMES ========================================*/


    $(".option").on("click", function () {
        $(".box").toggleClass("open");
    });

    $("body").on("click", function (o) {
        $(o.target).closest(".box").length || $(".box").removeClass("open");
    });

    $(".style1").on("click", function () {
        $("#color").attr("href", "css/color/style1.css");
    });

    $(".style2").on("click", function () {
        $("#color").attr("href", "css/color/style2.css");
    });

    $(".style3").on("click", function () {
        $("#color").attr("href", "css/color/style3.css");
    });

    $(".style4").on("click", function () {
        $("#color").attr("href", "css/color/style4.css");
    });

    $(".default").on("click", function () {
        $("#color").attr("href", "css/color/default.css");
    });
    $(".style5").on("click", function () {
        $("#color").attr("href", "css/color/style5.css");
    });


})(jQuery);