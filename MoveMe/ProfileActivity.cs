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

namespace MoveMe
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : Activity
    {
        Button map;
        Button about;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.file_profile);

            map = FindViewById<Button>(Resource.Id.map);
            about = FindViewById<Button>(Resource.Id.about);

            map.Click += delegate { StartActivity(typeof(MapActivity)); };
            about.Click += delegate { StartActivity(typeof(AboutActivity)); };
        }
        
    }
}