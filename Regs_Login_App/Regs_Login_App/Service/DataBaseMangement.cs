using Regs_Login_App.InterFace;
using Regs_Login_App.Model;
using Regs_Login_App.Utility;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Regs_Login_App.Service
{
   public class DataBaseMangement
    {
        private readonly SQLiteConnection sQLiteConnection;
         public DataBaseMangement()
        {
            sQLiteConnection = DependencyService.Get<SqLiteInterface1>().CreateConnection();
            sQLiteConnection.CreateTable<LoginTable>();
            sQLiteConnection.CreateTable<RegisterationTable>();
        }
        public List<RegisterationTable> RegisterUserList()
        {
            var users = sQLiteConnection.Table<RegisterationTable>().ToList();
            return users;
        }
        public RegisterResponse Register(RegisterationTable Rgmodel)
        {
            if (Rgmodel != null)
            {
                var list = sQLiteConnection.Table<RegisterationTable>().ToList();
                var response = sQLiteConnection.Table<RegisterationTable>().Where(x => x.Email.Equals(Rgmodel.Email) && x.Password.Equals(Rgmodel.Password));
                if (response.Count() > 0)
                {
                    return RegisterResponse.Invalid;
                }
                else
                {
                    sQLiteConnection.Insert(Rgmodel);
                    return RegisterResponse.Successful;
                }
            }
            return RegisterResponse.Failed;
        }
        public LoginResponse Login(LoginTable loginModel)
        {
            if (loginModel != null)
            {
                var list = sQLiteConnection.Table<RegisterationTable>().ToList();
                var response = sQLiteConnection.Table<RegisterationTable>().Where(y => y.Email.Equals(loginModel.UserName) && y.Password.Equals(loginModel.Password));
                if (response.Count() > 0)
                {
                    return LoginResponse.Successful;
                }
                else
                {

                    return LoginResponse.Invalid;
                }
            }
            return LoginResponse.Failed;
        }
    }
}
