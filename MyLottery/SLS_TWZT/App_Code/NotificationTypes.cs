using System;
using System.Reflection;

public class NotificationTypes
{
    public const string CustomChaseWin = "CustomChaseWin";
    public const string DistillAccept = "DistillAccept";
    public const string DistillNoAccept = "DistillNoAccept";
    public const string ExecChaseTaskDetail = "ExecChaseTaskDetail";
    public const string ForgetPassword = "ForgetPassword";
    public const string InitiateChaseTask = "InitiateChaseTask";
    public const string InitiateScheme = "InitiateScheme";
    public const string IntiateCustomChase = "IntiateCustomChase";
    public const string JoinScheme = "JoinScheme";
    public const string MobileValid = "MobileValid";
    public const string MobileValided = "MobileValided";
    public const string Quash = "Quash";
    public const string QuashChaseTask = "QuashChaseTask";
    public const string QuashChaseTaskDetail = "QuashChaseTaskDetail";
    public const string QuashScheme = "QuashScheme";
    public const string Register = "Register";
    public const string RegisterAdv = "RegisterAdv";
    public const string TryDistill = "TryDistill";
    public const string UserEdit = "UserEdit";
    public const string UserEditAdv = "UserEditAdv";
    public const string Win = "Win";

    public string this[short Index]
    {
        get
        {
            switch (Index)
            {
                case 1:
                    return "Register";

                case 2:
                    return "RegisterAdv";

                case 3:
                    return "ForgetPassword";

                case 4:
                    return "UserEdit";

                case 5:
                    return "UserEditAdv";

                case 6:
                    return "InitiateScheme";

                case 7:
                    return "JoinScheme";

                case 8:
                    return "InitiateChaseTask";

                case 9:
                    return "ExecChaseTaskDetail";

                case 10:
                    return "TryDistill";

                case 11:
                    return "DistillAccept";

                case 12:
                    return "DistillNoAccept";

                case 13:
                    return "Quash";

                case 14:
                    return "QuashScheme";

                case 15:
                    return "QuashChaseTaskDetail";

                case 0x10:
                    return "QuashChaseTask";

                case 0x11:
                    return "Win";

                case 0x12:
                    return "MobileValid";

                case 0x13:
                    return "MobileValided";

                case 20:
                    return "IntiateCustomChase";

                case 0x15:
                    return "CustomChaseWin";
            }
            return "";
        }
    }
}

