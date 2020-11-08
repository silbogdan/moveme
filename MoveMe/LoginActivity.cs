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
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        Button submitBtn;
        EditText pwdEditLogin;
        EditText usrEditLogin;
        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.file_login);
            pwdEditLogin = FindViewById<EditText>(Resource.Id.pwdEditLogin);
            usrEditLogin = FindViewById<EditText>(Resource.Id.usrEditLogin);
            submitBtn = FindViewById<Button>(Resource.Id.submitBtn);
            submitBtn.Click += MapPage;
        }

        public async void MapPage(object sender, EventArgs e)
        {
            if (usrEditLogin.Text != null && pwdEditLogin.Text != null)
            {
                Console.WriteLine("Map page");
                
                var user = await firebaseHelper.GetUser(usrEditLogin.Text);

                if (user != null && user.password == pwdEditLogin.Text)
                {
                    // Go to map page
                    //StartActivity(typeof(MapActivity));
                    StartActivity(typeof(MainActivity));
                } 
            }

        }
    }
}