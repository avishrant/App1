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
    public class OnDialogSignup : EventArgs
    {
        private string gFristName;
        private string gEmail;
        private string gPassword;
       
        public string FirstName
        {
            get { return gFristName; }
            set { gFristName = value; }
        }
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

        public OnDialogSignup ( string firstname, string email, string password) : base()//sign up button in the fragment
        {
            FirstName = firstname;
            Email = email;
            Password = password;
        }
    }
    class dialogsignup : DialogFragment
    
    {
        private EditText gTxtFirstName;
        private EditText gTxtEmail;
        private EditText gTxtPassword;
        private Button gbtndialogsignup;

        public event EventHandler<OnDialogSignup> gOnDialogSign;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.signupfrag, container, false);

            gTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            gTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            gTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            gbtndialogsignup = view.FindViewById<Button>(Resource.Id.btndialogsignup);

            gbtndialogsignup.Click += gbtndialogsignup_Click;

            return view;

        }

        void gbtndialogsignup_Click(object sender, EventArgs e)
        {
            //fragment signup button clicky clicky
            gOnDialogSign.Invoke(this, new OnDialogSignup(gTxtFirstName.Text, gTxtEmail.Text, gTxtPassword.Text));//invoking event, can also use OnDialogSing.Invoke
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