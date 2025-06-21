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


    document.getElementById("dob").addEventListener("change", function () {
        let dob = new Date(this.value);
        let today = new Date();
        let age = today.getFullYear() - dob.getFullYear();
        let monthDiff = today.getMonth() - dob.getMonth();

        if(monthDiff < 0 || (monthDiff === 0 && today.getDate() < dob.getDate())){
            age--;
        }
        document.getElementById("age").value = age;
    })

    document.getElementById("dob").addEventListener("input", function() {
        if (this.value) {
            this.classList.add("has-value"); 
        } else {
            this.classList.remove("has-value");
        }
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