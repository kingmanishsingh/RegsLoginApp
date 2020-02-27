using Regs_Login_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Regs_Login_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
