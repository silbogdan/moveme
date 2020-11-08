using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MoveMe.Helper;
using MoveMe.Models;

namespace MoveMe
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity, IOnMapReadyCallback
    {
        EditText searchEdit;
        Button searchBtn;

        Button ProfilePage;
        Button AboutPage;

        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.file_map);

            searchEdit = FindViewById<EditText>(Resource.Id.searchEdit);
            ProfilePage = FindViewById<Button>(Resource.Id.ProfilePage);
            AboutPage = FindViewById<Button>(Resource.Id.AboutPage);

            ProfilePage.Click += delegate { StartActivity(typeof(ProfileActivity)); };
            AboutPage.Click += delegate { StartActivity(typeof(AboutActivity)); };
            //searchBtn = FindViewById<Button>(Resource.Id.searchBtn);
            //searchBtn.Click += onSearch;

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }

       /*
        public async void onSearch(object sender, EventArgs e)
        {
            string curCity = searchEdit.Text;
            var searchedCity = await firebaseHelper.GetCity(curCity);
            
            if (searchedCity != null && searchedCity.cName == curCity)
            {
                var spots = await firebaseHelper.GetAllSpots();
                foreach (Spot s in spots)
                {
                    if (s.sCity == curCity)
                    {
                        MarkerOptions markerOpt = new MarkerOptions();
                        string[] scoordinates = s.sCoords.Split(",").ToString();

                        markerOpt.SetPosition(new LatLng(double.Parse(scoordinates[0]), double.Parse(scoordinates[1])));
                        markerOpt.SetTitle(s.sName);

                        var bmDescriptor = BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan);
                        markerOpt.InvokeIcon(bmDescriptor);

                        GoogleMap.AddMarker(markerOpt);
                    }
                }
            }
        } */

        public void OnMapReady(GoogleMap googleMap)
        {
            googleMap.MapType = GoogleMap.MapTypeNormal;
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
        }

    }
}