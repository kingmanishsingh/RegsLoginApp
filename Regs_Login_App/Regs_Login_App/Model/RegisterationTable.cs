using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Regs_Login_App.Model
{
    public class RegisterationTable
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

}
