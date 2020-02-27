using Regs_Login_App.Model;
using Regs_Login_App.Service;
using Regs_Login_App.Utility;
using Regs_Login_App.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Regs_Login_App.ViewModels
{
    class LoginVM : BindableObject

    {
     
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (value != null)
                {
                    password = value;
                    ValidatePassword();
                }
                OnPropertyChanged(nameof(Password));
            }
        }
        public string labelpassword;


        public string LabelPassword
        {
            get { return labelpassword; }
            set
            {
                labelpassword = value;
                OnPropertyChanged(nameof(LabelPassword));
            }
        }
        private bool isVisiblePassword;

        public bool IsVisiblePassword
        {
            get { return isVisiblePassword; }
            set
            {
                isVisiblePassword = value;
                OnPropertyChanged(nameof(IsVisiblePassword));
            }
        }
        public bool ValidatePassword()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password))
            {
                LabelPassword = "This Field is Required";
                IsVisiblePassword = true;
                isValid = false;
            }
            else
            {
                LabelPassword = string.Empty;
                IsVisiblePassword = false;
                isValid = true;
            }
            return isValid;
        }
        private readonly DataBaseMangement dataBaseMangement;
        public LoginVM()
        {
            this.dataBaseMangement = new DataBaseMangement();
        }


        private string username;

        public string UserName
        {
            get { return username; }
            set
            {
                if (value != null)
                {
                    username = value;
                    ValidateName();
                }
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string labelname;


        public string LabelName
        {
            get { return labelname; }
            set
            {
                labelname = value;
                OnPropertyChanged(nameof(LabelName));
            }
        }
        //public bool IsVisibleName { get; private set; }
        private bool isVisibleName;

        public bool IsVisibleName
        {
            get { return isVisibleName; }
            set
            {
                isVisibleName = value;
                OnPropertyChanged(nameof(IsVisibleName));
            }
        }


        public bool Validation()
        {
            bool isValid = false;
            if (!ValidateName())
            {
                return false;
            }
            else if (!ValidatePassword())
            {
                return false;
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }   
        public bool ValidateName()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrWhiteSpace(UserName))
            {
                LabelName = "Please Enter Email Id";
                IsVisibleName = true;
                return isValid = false;

            }
            else
            {
                LabelName = string.Empty;
                //isValid = false;
                if (!Regex.IsMatch(username, Constants.emailRegexPattern))
                {
                    LabelName = "Please Enter Valid Email";
                    IsVisibleName = true;
                    return isValid = false;
                }
                IsVisibleName = false;
                isValid = true;
            }
            return isValid;
        }

        private Command loginBt;
        public Command LoginBt
        {

            get
            {
                if (loginBt == null)
                {
                    loginBt = new Command(async (response) =>
                    {
                        LoginTable loginTab = null;
                        var ResponseData = response as LoginVM;

                        var isSuccess = Validation();
                        if (isSuccess)
                        {
                            if (ResponseData != null)
                            {
                                loginTab = new LoginTable()
                                {
                                    
                                    UserName = ResponseData.UserName,
                                    Password =  ResponseData.Password
                                };
                            }

                            LoginResponse resp = dataBaseMangement.Login(loginTab);
                            if (resp.Equals(LoginResponse.Successful))
                            {
                                await App.Current.MainPage.Navigation.PushModalAsync(new MediaPage());
                            }
                            else if (resp.Equals(RegisterResponse.Invalid))
                            {
                                await App.Current.MainPage.DisplayAlert("Message", " User Id or Password is Invalid ", "Ok");
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("Message", " Enter Wrong Id and Password!", "Ok");
                            }
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Registration", "Enter User Id and Password!", "Ok");
                        }


                    });
                }
                return loginBt;
            }

           
        }
        private Command signupBt;
        public Command SignupBt => signupBt = new Command(async (response) =>
        {
           
            await App.Current.MainPage.Navigation.PushModalAsync(new RegistrationPage());


        });


    }

    
}
