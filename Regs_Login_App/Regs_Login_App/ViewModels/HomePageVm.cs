using Regs_Login_App.Model;
using Regs_Login_App.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Regs_Login_App.ViewModels
{
   public class HomePageVm : BindableObject
    {
        private readonly DataBaseMangement databaseManager;
        private List<RegisterationTable> users;
        public List<RegisterationTable> Users
        {
            get { return users; }
            set
            {
                if (value != null)
                {
                    users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }
        public HomePageVm()
        {
            databaseManager = new DataBaseMangement();
            Users = databaseManager.RegisterUserList();
        }

    }
}
