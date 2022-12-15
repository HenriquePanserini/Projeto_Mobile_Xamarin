using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using AppTol.Droid.Controller;
using AppTol.Models;

[assembly: Dependency(typeof(GetDeviceVersion_Android))]
namespace AppTol.Droid.Controller
{

    
    public class GetDeviceVersion_Android : IDeviceInfo
    {
        public string GetOSVersion()
        {
            return Convert.ToString((int)Build.VERSION.SdkInt).Trim();
        }
    }
}