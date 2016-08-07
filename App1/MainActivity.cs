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
    [Activity()]
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
                //login fragment
                FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialoglogin logindialog = new dialoglogin();
                logindialog.Show(trans, "fragment dialog");
                logindialog.gOnDialogLogin += logindialog_gOnDialogLogin; //need void dialoglogin_gOnDialogLogin{see below}

            };
            
            gbtnsignup = FindViewById<Button>(Resource.Id.btnsignup);//signup button, first screen

            gbtnsignup.Click += (object sender, EventArgs e) =>      //need to subscribe to this event
            {
                //signup fragment
                FragmentTransaction trans = FragmentManager.BeginTransaction();//using events, do not want to use methods
                dialogsignup signupdialog = new dialogsignup();
                signupdialog.Show(trans, "fragment dialog");

                signupdialog.gOnDialogSign += dialogsignup_gOnDialogSign;
            };
        }
        void logindialog_gOnDialogLogin(object sender, OnDialogLogin e)
        {
           
        }

       
        void dialogsignup_gOnDialogSign(object sender, OnDialogSignup e)
        {
            // try making a global variable to instantiate the email and password fields, and try after that.
            //if it doesn't work, make a dummy thread, and proceed. 
        


            using (StreamWriter writer = new StreamWriter("info.txt"))//Thread thread = new Thread(dummy);
                                                                //thread.start();
            //private void dummy() {Thread.Sleep(3000);}
            {
                writer.Write(e.Email);
                writer.Write(e.FirstName);
                writer.Write(e.Password);
            }
        }
        }
        }
        
    


