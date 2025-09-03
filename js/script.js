$(document).ready(function(){
    $(".has-dropdown").click(function () {
        $(this).toggleClass("clicked")
    })
});

  $(document).ready(function () {
    var currentPage = window.location.pathname.split("/").pop(); // e.g., 'career.html'

    if (currentPage === "") {
      currentPage = "index.html"; // Default to index.html if no file name in URL
    }

    $(".nav-list a").each(function () {
      var href = $(this).attr("href");

      if (href === currentPage) {
        $(this).addClass("active");
      }
    });
  });

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
    
      
      $(window).on('click', function (e) {
        if ($(e.target).is('#myModal')) {
          $('#myModal').fadeOut();
        }
      });
    });
        
    $('.management').owlCarousel({
    loop:true,
    margin:20,
    dots:false,
    nav:true,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    mouseDrag:false,
    autoplay:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:3
        }
    }
});

 $('.access-slider').owlCarousel({
    loop:true,
    margin:20,
    dots:false,
    nav:true,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    mouseDrag:false,
    autoplay:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:3
        }
    }
});

 $('.circular-space').owlCarousel({
    loop:true,
    margin:20,
    dots:false,
    nav:true,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    mouseDrag:false,
    autoplay:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:3
        }
    }
});
$('.future-slider').owlCarousel({
    loop:true,
    margin:20,
    dots:false,
    nav:true,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    mouseDrag:false,
    autoplay:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
});

$('.keyfeaturesSlider').owlCarousel({
    loop:true,
    margin:20,
    dots:true,
    nav:false,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    mouseDrag:true,
    autoplay:false,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:4
        }
    }
});
$(document).ready(function () {
      $('.detail-link').on('click', function () {
        var target = $(this).data('target');

        if ($(target).is(':visible')) {
          $(target).slideUp(); // hide if already visible
        } else {
          $('.content').slideUp(); // hide all
          $(target).slideDown();   // show selected
        }
      });
    });