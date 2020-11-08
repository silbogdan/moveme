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
using MoveMe.Helper;
using MoveMe.Models;

namespace MoveMe
{
    [Activity(Label = "SignActivity")]
    public class SignActivity : Activity
    {
        Button registerBtn;
        EditText firstnameEdit;
        EditText lastnameEdit;
        EditText cityEdit;
        EditText usernameEdit;
        EditText passwordEdit;
        EditText confirmPassEdit;
        EditText emailEdit;

        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.file_signup);
            firstnameEdit = FindViewById<EditText>(Resource.Id.firstnameEdit);
            lastnameEdit = FindViewById<EditText>(Resource.Id.lastnameEdit);
            cityEdit = FindViewById<EditText>(Resource.Id.cityEdit);
            usernameEdit = FindViewById<EditText>(Resource.Id.usernameEdit);
            passwordEdit = FindViewById<EditText>(Resource.Id.passwordEdit);
            confirmPassEdit = FindViewById<EditText>(Resource.Id.confirmpass);
            emailEdit = FindViewById<EditText>(Resource.Id.emailEdit);

            registerBtn = FindViewById<Button>(Resource.Id.registerBtn);
            registerBtn.Click += MapPage;
        }

        public async void MapPage(object sender, EventArgs e)
        {
            if (firstnameEdit.Text != null && lastnameEdit.Text != null && cityEdit.Text != null && usernameEdit.Text != null
                && passwordEdit.Text != null && confirmPassEdit.Text != null && passwordEdit.Text == confirmPassEdit.Text)
            {
                await firebaseHelper.AddUser(usernameEdit.Text, passwordEdit.Text, firstnameEdit.Text, lastnameEdit.Text,
                    emailEdit.Text, cityEdit.Text);
                Console.WriteLine("User added");
                firstnameEdit.Text = String.Empty;
                lastnameEdit.Text = String.Empty;
                cityEdit.Text = String.Empty;
                usernameEdit.Text = String.Empty;
                passwordEdit.Text = String.Empty;
                confirmPassEdit.Text = String.Empty;
                StartActivity(typeof(LoginActivity));
            } 
        }
    }
}