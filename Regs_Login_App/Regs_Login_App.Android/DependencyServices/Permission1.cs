using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Regs_Login_App.Droid.DependencyServices;
using Regs_Login_App.Service;
using Xamarin.Forms;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;

[assembly: Dependency(typeof(Permission1))]

namespace Regs_Login_App.Droid.DependencyServices
{
    public class Permission1 : Permissions
    {
        public delegate bool CheckCamaraPermitionDelegate();
        public delegate bool CheckReadWritePermitionDelegate();

        public delegate void GetCamaraPermitionDelegate();
        public delegate void GetReadWritePermitionDelegate();

        public static event CheckCamaraPermitionDelegate CheckCamara;
        public static event CheckReadWritePermitionDelegate CheckReadWrite;

        public static event GetCamaraPermitionDelegate GetCamara;
        public static event GetReadWritePermitionDelegate GetReadWrite;


        public bool CheckCamaraPermission()
        {
            bool responce = false;
            try
            {
                responce = CheckCamara();
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                
            }
            return responce;
        }

        public bool CheckReadWritePermission()
        {
            bool responce = false;
            try
            {
                responce = CheckReadWrite();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return responce;
        }

        public void GrantCamaraPremission()
        {
            try
            {
                GetCamara();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public void GrantReadWritePremission()
        {
            try
            {
                GetReadWrite();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}