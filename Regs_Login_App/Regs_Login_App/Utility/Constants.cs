using System;
using System.Collections.Generic;
using System.Text;

namespace Regs_Login_App.Utility
{
  public  class Constants
    {
        public static string emailRegexPattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
        public static string passwordRegexPattern = "(?=.{8,})";

             public static string PhoneNumber = "(?=.{10,})";


    }
}
