using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Regs_Login_App.Model
{
   public class LoginTable
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
