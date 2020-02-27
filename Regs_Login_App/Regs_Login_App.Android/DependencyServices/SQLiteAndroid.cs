using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Regs_Login_App.Droid.DependencyServices;
using Regs_Login_App.InterFace;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace Regs_Login_App.Droid.DependencyServices
{
    public class SQLiteAndroid : SqLiteInterface1
    {
        public SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection
             (
              Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "mydatabase.db3")
             );
        }
    }
}