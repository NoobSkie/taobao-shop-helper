$(document).ready(function(){
	if($('#topmid').html()==""){
		$('#topmid').load('/public/common.aspx #topmid>*',function(){setLoginInfo();renderMenu();});
		$('#footer').load('/public/common.aspx #bottom');
	}else
	{
		setLoginInfo();
		renderMenu();
	}
});


function renderMenu(e) {
    var w=0;

	siteWidth = $(".site-nav").width();
	parentOffsetLeft = $('#floor_nav').offset().left;

	$("#floor_nav ul.floors li").each(function(i) {
		offset = $(this).offset(); 
		menu = $('#sub_' + this.id);
        $('#sub_' + this.id).css("width",w+"px")
		leftPosition = offset.left-parentOffsetLeft ;
		if(w+leftPosition > siteWidth ){ 
			leftPosition=siteWidth-w-$(this).width();
		}

		menu.css("left", leftPosition + "px");
		menu.css("left",(parseInt(menu.css("left"))-83)+"px");
		menu.css("top", "31px");

		menu.find(".dht").css("height",menu.height()+"px");
		menu.bgiframe(); //fix for ie6
		$(this).dropdown({ menu: menu, type: 'simple'});
	});
}

(function($){
$.fn.dropdown = function(opt){
    
    var defaults = {
        speed: 0,
        delay: 50,
        type: 'slide',
        transIn: {opacity: 'show'},
        transOut: {opacity: 'hide'}     
    };
    
    var options = $.extend(defaults, opt);
    
    var menu = $(options.menu);
    var speed = options.speed;
    var delay = options.delay;
    var type = options.type;
    var transIn = options.transIn;
    var transOut = options.transOut;
    
    var menuOver = false;
    var buttonOver = false;
    
    //find the top level menu image
    var topLevelMenuImage = $(this).find('a img')[0];
    
    //find top level anchor
    var topLevelAnchor = $(this).find('a')[0];
    
    var topNavItem = "";
   
	var topNavConfig = {    
		 sensitivity: 9, // number = sensitivity threshold (must be 1 or higher)    
		 interval: 0, // number = milliseconds for onMouseOver polling interval    
		 over: topNavOver, // function = onMouseOver callback (REQUIRED)    
		 timeout: 200, // number = milliseconds delay before onMouseOut    
		 out: topNavOut // function = onMouseOut callback (REQUIRED)    
	};
	
	var subNavConfig = {    
		 sensitivity: 99999, // number = sensitivity threshold (must be 1 or higher)    
		 interval: 0, // number = milliseconds for onMouseOver polling interval    
		 over: subNavOver, // function = onMouseOver callback (REQUIRED)
		 timeout: 200, // number = milliseconds delay before onMouseOut    
		 out: subNavOut // function = onMouseOut callback (REQUIRED)    
	};

    $(menu).hide();
    $(this).hoverIntent(topNavConfig);
	$(menu).hoverIntent(subNavConfig);

    function topNavOver(){
		$(".menu").hide();
		$(topLevelAnchor).parent().siblings("li").children("a.active").removeClass("active");
        if(menu.is(':animated')){return};
        if(parseInt(menu.css("left"))<0)
            menu.css("left","1px");
        //alert(menu.css("left"));
        switch(type)
        {
            case 'slide':
                $(menu).slideDown(speed);
                break;
            case 'fade':
                $(menu).fadeIn(speed);
                break;
            case 'simple':
                $(menu).show();
                break;
            case 'blind':
                $(menu).show("blind", { direction: "vertical" }, 200);
                break;
            case 'custom':
                $(menu).animate(transIn, speed)
        }
        buttonOver = true;
        $(topLevelAnchor).addClass("active");
    }

    function topNavOut(){
        buttonOver = false;
        setTimeout(function(){
            if(menuOver == false && buttonOver == false){
                switch(type)
                {
                    case 'slide':
                        $(menu).slideUp(speed);
                        break;
                    case 'fade':
                        $(menu).fadeOut(speed);
                        break;
                    case 'simple':
                        $(menu).hide();
                        break;
                    case 'blind':
                        $(menu).hide("blind", { direction: "vertical" }, 200);
                        break;
                    case 'custom':
                    $(menu).animate(transOut, speed)
                }
                $(topLevelAnchor).removeClass("active"); 
            }
        }, delay);
        
    }

    function subNavOver (){
        menuOver = true;
        $(topLevelAnchor).addClass("active");
   } 

    function subNavOut(){
        menuOver = false;
        setTimeout(function(){
            if(menuOver == false && buttonOver == false){
                switch(type)
                {
                case 'slide':
                    $(menu).slideUp(speed);
                    break;
                case 'fade':
                    $(menu).fadeOut(speed);
                    break;
                case 'simple':
                    $(menu).hide();
                    break;
                case 'custom':
                    $(menu).animate(transOut, speed)
                }
                $(topLevelAnchor).removeClass("active");
            }
        }, delay);
    }

}
})

(jQuery);

