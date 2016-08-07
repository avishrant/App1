using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace App1
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]

    public class splash : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
           


            base.OnCreate(bundle);
            Thread.Sleep(10000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

       
           


        }
    }
