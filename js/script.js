jQuery(window).scroll(function () {
    if (jQuery(this).scrollTop() > 165) {
        jQuery("header").addClass("fixed-header")
    } else {
        jQuery("header").removeClass("fixed-header")
    }
})

$(document).ready(function () {
    $("#collapsable").click(function () {
        $(".nav-list").toggleClass("active"); // Toggle 'active' class
    });
});


$(document).ready(function() {

    $('.tab_header .item').on("click",function(){
        var number = $(this).data("option");
    
        $('.tab_header .item').removeClass('active');
    
        $(this).addClass('active');
    
        $('.tab_container .container_item').hide();
        $('div[data-item="'+ number +'"]').show();
    });
    
    });
    $('.curriculum-slider').owlCarousel({
                loop: true,
                margin: 50,
                nav: false,
                dots: false,
                navText: ['<i class="fa-solid fa-arrow-left"></i>', '<i class="fa-solid fa-arrow-right"></i>'],
                autoplay: false,
                autoplayTimeout: 7000,
                smartSpeed: 800,
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 2
                    },
                    1000: {
                        items: 2,
                        stagePadding: 220,
                    }
                }
            })
    
            $(document).ready(function () {
      // Open modal
      $('#foundation').on('click', function () {
        $('#myModal').fadeIn();
      });
    
      // Close modal
      $('.close').on('click', function () {
        $('#myModal').fadeOut();
      });
    
      // Close modal when clicking outside the content
      $(window).on('click', function (e) {
        if ($(e.target).is('#myModal')) {
          $('#myModal').fadeOut();
        }
      });
    });