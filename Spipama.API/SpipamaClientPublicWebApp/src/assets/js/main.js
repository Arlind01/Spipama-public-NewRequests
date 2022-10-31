(function ($) {
	"use strict";

    $(document).ready(function($){

        $(".embed-responsive iframe").addClass("embed-responsive-item");
        $(".carousel-inner .item:first-child").addClass("active");
        $('[data-toggle="tooltip"]').tooltip();
		
		//Fixed nav on scroll
		$(document).on('scroll',function(e){
			var scrollTop = $(document).scrollTop();
			if(scrollTop > $('#navbar-1').height()){
				$('#navbar-1').addClass('fixed-top');
				$('#navbar-1').removeClass('navbar-1');
			}
			else {
				$('#navbar-1').addClass('navbar-1');
				$('#navbar-1').removeClass('fixed-top');
			}
			
			if(scrollTop > $('#navbar-2').height()){
				$('#navbar-2').addClass('fixed-top-2');
				$('#navbar-2').removeClass('navbar-2');
			}
			else {
				$('#navbar-2').addClass('navbar-2');
				$('#navbar-2').removeClass('fixed-top-2');
			}
		});

		//Testimonial
		$('.testimonials-cont').owlCarousel({
                loop: true,
                margin: 30,
                responsiveClass: true,
                responsive: {
                  0: {
                    items: 1,
                    nav: false
                  },
                  600: {
                    items: 1,
                    nav: false
                  },
                  1000: {
                    items: 1,
                    nav: false,
                 
                  }
                }
		});
		
		
		//Portfolio Popup
		$('.magnific-popup').magnificPopup({type:'image'});
		
		//Video popup
		$('.popup-youtube').magnificPopup({
			type: 'iframe'
		});
        
		//Smooth Scroll
		smoothScroll.init();
		
		//active on scroll
		$('body').scrollspy({ 
        	target: '.navbar',
        	offset: 80
    	})

    });


    $(window).on('load',function(){
		
		//Preloader
		$('.preloader').delay(500).fadeOut('slow');
        $('body').delay(500).css({'overflow':'visible'});

		//Portfolio container			
		var $container = $('.portfolioContainer .row');
		$container.isotope({
			filter: '*',
			animationOptions: {
				duration: 750,
				easing: 'linear',
				queue: false
			}
		});
 
		$('.portfolioFilter a').on('click', function(){
			$('.portfolioFilter a').removeClass('current');
			$(this).addClass('current');
	 
			var selector = $(this).attr('data-filter');
			$container.isotope({
				filter: selector,
				animationOptions: {
					duration: 750,
					easing: 'linear',
					queue: false
				}
			 });
			 return false;
		}); 
		//WOW Js
        new WOW().init();
        
    });


}(jQuery));	