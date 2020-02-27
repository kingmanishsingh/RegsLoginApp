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
   public class RegistrationVM : BindableObject
    {
        private readonly DataBaseMangement dataBaseMangement;
        public RegistrationVM()
        {
            this.dataBaseMangement = new DataBaseMangement();
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value != null)
                {
                    phoneNumber = value;
                    ValidatePhoneNumber();
                }
                OnPropertyChanged(nameof(PhoneNumber));
            }

        }


        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                if (value != null)
                {
                    userName = value;
                    ValidateUserName();
                }
                OnPropertyChanged(nameof(userName));
            }
        }
        private string labelUserName;

        public string LabelUserName
        {
            get { return labelUserName; }
            set
            {
                labelUserName = value;
                OnPropertyChanged(nameof(LabelUserName));
            }
        }

        private bool isVisibleUserName;
        public bool IsVisibleUserName
        {
            get { return isVisibleUserName; }
            set
            {
                isVisibleUserName = value;
                OnPropertyChanged(nameof(IsVisibleUserName));
            }
        }
        public bool ValidateUserName()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrWhiteSpace(UserName))
            {
                LabelUserName = "This Field is Required";
                IsVisibleUserName = true;
                isValid = false;
            }
            else
            {
                LabelUserName = string.Empty;
                IsVisibleUserName = false;
                isValid = true;
            }
            return isValid;
        }
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                if (value != null)
                {
                    email = value;
                    ValidateEmail();
                }
                OnPropertyChanged(nameof(Email));
            }

        }
        private string labelEmail;

        public string LabelEmail
        {
            get { return labelEmail; }
            set
            {
                labelEmail = value;
                OnPropertyChanged(nameof(LabelEmail));
            }
        }
        private bool isvisibleEmail;

        public bool IsVisibleEmail
        {
            get { return isvisibleEmail; }
            set
            {

                isvisibleEmail = value;
                OnPropertyChanged(nameof(IsVisibleEmail));
            }
        }      

        /// <summary>
        ///  Validate Email 
        /// </summary>
       
        public bool ValidateEmail()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email))
            {
                LabelEmail = "Please Enter Email Id";
                IsVisibleEmail = true;
                return isValid = false;

            }
            else
            {
                LabelEmail = string.Empty;
                
                if (!Regex.IsMatch(email, Constants.emailRegexPattern))
                {
                    LabelEmail = "Please Enter Email Id";
                    IsVisibleEmail = true;
                    return isValid = false;
                }
                IsVisibleEmail = false;
                isValid = true;
            }
            return isValid;
        }

      
        public bool ValidatePhoneNumber()
        {
            bool isValid = false;
            if ( (!string.IsNullOrEmpty(PhoneNumber)) || string.IsNullOrWhiteSpace(PhoneNumber))
            {
                LabelPhoneNumber = "Please Enter 10 Digit Number";
                IsVisiblePhoneNumber = true;
                isValid = true;
            }
            else
            {
                LabelPhoneNumber = "Please Enter 10 Digit Number";
                IsVisiblePhoneNumber = false;
                isValid = false;
            }
            return isValid;
        }
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
        public bool ValidatePassword()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password))
            {
                LabelPassword = "This Field is Required";
                IsvisiblePassword = true;
                isValid = false;
            }
            else
            {
                LabelPassword = string.Empty;
                if (!Regex.IsMatch(password, Constants.passwordRegexPattern))
                {
                    LabelPassword = "More then 8 character required";
                    IsvisiblePassword = true;
                    return isValid = false;
                }
                IsVisibleEmail = false;
                isValid = true;
            }
            return isValid;
        }
        private string labelPassword;

        public string LabelPassword
        {
            get { return labelPassword; }
            set
            {
                labelPassword = value;
                OnPropertyChanged(nameof(LabelPassword));
            }
        }
        private bool isvisiblePassword;

        public bool IsvisiblePassword
        {
            get { return isvisiblePassword; }
            set
            {
                isvisiblePassword = value;
                OnPropertyChanged(nameof(IsvisiblePassword));
            }
        }

        private string labelPhoneNumber;

        public string LabelPhoneNumber
        {
            get { return labelPhoneNumber; }
            set
            {
                labelPhoneNumber = value;
                OnPropertyChanged(nameof(LabelPhoneNumber));
            }
        }
        private bool isVisiblePhoneNumber;

        public bool IsVisiblePhoneNumber
        {
            get { return isVisiblePhoneNumber; }
            set
            {
                isVisiblePhoneNumber = value;
                OnPropertyChanged(nameof(isVisiblePhoneNumber));
            }
        }
        private Command registerCommand;
        public Command RegisterCommand
        {
            get
            {
                try
                {

                    if (registerCommand == null)
                    {
                        registerCommand = new Command(async (response) =>
                        {


                            var responseData = response as RegistrationVM;

                            var isSuccess = Validation();


                            if (isSuccess)
                            {
                                RegisterationTable registerationTable = new RegisterationTable()
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    Email = responseData.Email,
                                    PhoneNumber = responseData.PhoneNumber,
                                    UserName = responseData.UserName,
                                    Password = responseData.Password,
                                };

                                RegisterResponse res = dataBaseMangement.Register(registerationTable);
                                if (res.Equals(RegisterResponse.Successful))
                                {
                                    await App.Current.MainPage.DisplayAlert("Message", "Registration Sucessed", "Ok");
                                    await App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                                }
                                else if (res.Equals(RegisterResponse.Invalid))
                                {
                                    await App.Current.MainPage.DisplayAlert("Message", "This Email ID is Already Registered Please Use another Email ID ", "Ok");
                                }
                                else
                                {
                                    await App.Current.MainPage.DisplayAlert("Message", "There is something Wrong!", "Ok");
                                }
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("Registration", "There is something wrong!", "Ok");
                            }

                        });
                    }
                }
                catch (Exception e)
                {
                }
                return registerCommand;
            }

        }
        public bool Validation()
        {
            bool isValid = false;
            if (!ValidateEmail())
            {
                return false;
            }
            else if (!ValidateUserName())
            {
                return false;
            }
            else if (!ValidatePassword())
            {
                return false;
            }
            else if (!ValidatePhoneNumber())
            {
                return false;
            }
              else
            {
                isValid = true;
            }
            return isValid;
        }


    }
}
