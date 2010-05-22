// JScript 文件
//定义变量
//用户帐户
var ajaxUrl="https://www.vancl.com/";
//登录地址
var loginUrl="https://www.vancl.com/";
//商品数
var itemCount=0;
$(document).ready(function()
{
    //设置用户信息
    setShoppingCar();
    //$("#spanCount").DMenu("#content");
    
    //放在site_nav中调用此函数,因为在帮助中心中,$("#welcome")是后生成的.
   //setLoginInfo();
});
function setLoginInfo()
{
	 if(hasLogin())
    {
        setWelcome();
    }
}
//判断用户是否登录
function hasLogin()
{
    return getCookie("UserLogin")!="";
}

//异步获取用户登录名称.
function setWelcome()
{
    $.getScript(ajaxUrl+"Usercenter/GetUserName.ashx", function()
            {
                if(typeof(data)!=undefined&&data!="")
                {
                    $("#login").html("<a class='top'  href='"+ajaxUrl+"login/UserLoginOut.aspx' target='_parent' >退出登录</a>");
                       $("#welcome").html("您好，<a class='top'  href='"+ajaxUrl+"UserCenter/OrderList.aspx'>"+data+"</a>。<a class='top'  href='"+ajaxUrl+"Login/UserLoginOut.aspx' target='_parent' >退出登录</a>");
                }
                else
                {
                    return;           
                }
            }
        );  
}

//获取购物车内的物品数
function setShoppingCar()
{
	 $.getScript(ajaxUrl+"Usercenter/GetUserShoppingCarInfo.ashx", function()
            {
            
                if(typeof car_info!='undefined'&&car_info!="")
                {
                    $("#prdCount").val(car_info.TotCount);
                    $("#price").html(car_info.TotMoney+"");
                }
        } );
}