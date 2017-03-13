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
using Android.Text;
using System.IO;
using Android.Graphics;
using System.Net;

namespace WeatherApp3
{
    [Activity(Label = "Display Weather")]
    public class DisplayWeather : Activity
    {
        string weatherIconURL = "http://openweathermap.org/img/w/@WICODE@.png";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            /**
            Takes values from intent and displays them in the design view objects
            */
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DisplayWeather);
            FindViewById<TextView>(Resource.Id.LocationView).Text = Intent.GetStringExtra("SearchTown");
            FindViewById<TextView>(Resource.Id.WeatherDescription).Text = Intent.GetStringExtra("WeatherType");
            double tempInCel = Intent.GetDoubleExtra("CurrentTemperature", -1);
            tempInCel = Math.Round(((tempInCel - 32) * 5 / 9),1);
            FindViewById<TextView>(Resource.Id.TempatureView).Text = tempInCel.ToString() + "°C";
            string SunRise = Intent.GetStringExtra("SunRise");
            FindViewById<TextView>(Resource.Id.SunRiseView).Text =SunRise.Substring(SunRise.Length-8);
            string SunSet = Intent.GetStringExtra("SunSet");
            FindViewById<TextView>(Resource.Id.SunSetView).Text = SunSet.Substring(SunSet.Length - 8);
            string weatherIconCode = Intent.GetStringExtra("WeatherIcon");
            string url = weatherIconURL.Replace("@WICODE@", weatherIconCode);
            var imageBitMap = getBmpFromURL(url);
            FindViewById<ImageView>(Resource.Id.WeatherIcon).SetImageBitmap(imageBitMap);
            FindViewById<Button>(Resource.Id.makeHomeLocation).Click += makeHome;
        }

        void makeHome(object sender, EventArgs e)
        {
            /**
            Sets home town user preference in the application data ready for next time the application is used
            */
            var prefs = Application.Context.GetSharedPreferences(Application.PackageName, FileCreationMode.Private);
            var prefEditer = prefs.Edit();
            prefEditer.PutString("homeTown", Intent.GetStringExtra("SearchTown"));
            prefEditer.Commit();
        }

        protected Bitmap getBmpFromURL(string picURL)
        {
            /**
            gets an weather icon from a API call to open weather API and Explicitly cast to a bitMap
            */
            Bitmap imageBitmap = null;
            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(picURL);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }
    }
}