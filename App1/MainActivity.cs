using System;
using System.IO;
using System.Threading;
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
        private Button gbtnsignup; //global variable
        private Button gbtnlogin; //global variable


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Set our view from the "main" layout resource


           gbtnlogin = FindViewById<Button>(Resource.Id.btnlogin);//login button, first
            gbtnlogin.Click += (object sender, EventArgs e) =>
            {
                //show login fragment
                FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialoglogin logindialog = new dialoglogin();
                logindialog.Show(trans, "fragment dialog");
                logindialog.gOnDialogLogin += logindialog_gOnDialogLogin; //need void dialoglogin_gOnDialogLogin{see below}

            };
            
            gbtnsignup = FindViewById<Button>(Resource.Id.btnsignup);//signup button, first screen

            gbtnsignup.Click += (object sender, EventArgs e) =>      //need to subscribe to this event
            {
                //show signup fragment
                FragmentTransaction trans = FragmentManager.BeginTransaction();//using events, do not want to use methods
                dialogsignup signupdialog = new dialogsignup();
                signupdialog.Show(trans, "fragment dialog");

                signupdialog.gOnDialogSign += dialogsignup_gOnDialogSign;
            };

        }
        void logindialog_gOnDialogLogin(object sender, OnDialogLogin e)
        {
            Thread thread = new Thread(dummy);
            thread.Start();
        }


        void dialogsignup_gOnDialogSign(object sender, OnDialogSignup e)
        {
            // try making a global variable to instantiate the email and password fields, and try after that.
            //if it doesn't work, make a dummy thread, and proceed. 


            Thread thread = new Thread(dummy);
            
        }
            private void dummy()
        {
            Thread.Sleep(3000);
        }
            
        }
        }
        
        
    


