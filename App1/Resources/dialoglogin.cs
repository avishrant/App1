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

namespace App1
{
    
    public class OnDialogLogin : EventArgs
    {
        private string gEmail;
        private string gPassword;

        public string Email
        {
            get { return gEmail; }
            set { gEmail = value; }
        }
        public string Password
        {
            get { return gPassword; }
            set { gPassword = value; }
        }
        public OnDialogLogin(string email, string password) : base()//main login
        {
            Email = email;
            Password = password;
        }
    }
    class dialoglogin : DialogFragment
    {
        private EditText gTxtEmail;
        private EditText gTxtPassword;
        private Button gbtndialoglogin;

        public event EventHandler<OnDialogLogin> gOnDialogLogin;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.loginfrag, container, false);

            gTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            gTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            gbtndialoglogin = view.FindViewById<Button>(Resource.Id.btndialoglogin);

            return view;

        }
        void gbtndialoglogin_Click(object sender, EventArgs e)
        {
            //fragment signup button clicky clicky
            gOnDialogLogin.Invoke(this, new OnDialogLogin(gTxtEmail.Text, gTxtPassword.Text));//invoking event, can also use OnDialogSing.Invoke
            this.Dismiss();
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //invisible title bar
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.signupanimation; //setting animation
        }
    }
}