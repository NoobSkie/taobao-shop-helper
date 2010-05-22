function OnMenuBarClick(sender)
{
    sender = document.getElementById(sender);
            
    for (var i = 1; i <= 3; i++)
    {            
        var obj = document.getElementById("MenuBar_" + i);
                
        if (!obj)
        {
            continue;
        }
                
        if (obj == sender)
        {
            sender.style.display = (sender.style.display == "") ? "none" : "";
        }
        else
        {
            obj.style.display = "none";
        }
    }
}


