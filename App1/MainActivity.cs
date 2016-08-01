using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button gbtnsignup;
        private Button gbtnlogin;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            gbtnsignup = FindViewById<Button>(Resource.Id.btnsignup);

            gbtnsignup.Click += (object sender, EventArgs e) =>
            {
                //shows the fragment display
                FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialogsignup signupdialog = new dialogsignup();
                signupdialog.Show(trans, "fragment dialog");
            };

            gbtnlogin = FindViewById<Button>(Resource.Id.btnlogin);

            gbtnlogin.Click += (object sender, EventArgs e) =>
            {
                //login fragment
                FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialoglogin logindialog = new dialoglogin();
                logindialog.Show(trans, "fragment dialog");
            };
            
        }
        
    }
}

