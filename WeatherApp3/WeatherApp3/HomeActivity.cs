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
using System.Xml;
using System.IO;
using System.Net;
using Org.Apache.Http.Impl.Client;
using Org.Apache.Http;

namespace WeatherApp3
{
    [Activity(Label = "Home")]
    public class HomeActivity : Activity
    {
        private const string API_KEY = "6fa9263c8e92842765f709addcae4d49";
        private const string currentURL = "http://api.openweathermap.org/data/2.5/weather?" + "q=@LOCATION@&mode=xml&units=imperial&APPID=" + API_KEY;
        //  private const string forcastURL = "http://api.openweathermap.org/data/2.5/forecast?" + "q=@LOCATION@&mode=xml&units=imperial&APPID=" + API_KEY;
        /**
        Constant String for API KEY used in the openWeatherMap api
        Basic string for current weather and forecast weather (@LOATION@ replaced with the town the user enters before send api call)
            */

        protected override void OnCreate(Bundle savedInstanceState)
        {
            /**
            on create sets layout, reads home town preference if there is any and holds search button on click delegate call
                */
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomeActivity);
            string homeTownPref = getPreferences();
            if (homeTownPref != "")
            {
                FindViewById<EditText>(Resource.Id.enteredTownText).Text = homeTownPref;
            }
            FindViewById<Button>(Resource.Id.search).Click += searchOnClick;
        }

        void searchOnClick(object sender, EventArgs e)
        {
         /**
            when the search button is clicked the input is trimmed of any unnecessary white space and set to a string homeTown.
            string URL adds a town to the weather api call url         
            */   
            string homeTown = FindViewById<EditText>(Resource.Id.enteredTownText).Text.Trim();
            string url = currentURL.Replace("@LOCATION@", homeTown);
            /**
            send url to function getFormattedXml   
            */
            XmlDocument xmlTEXT = getFormattedXml(url);
            /**
            call function that returns a new intent with the values needed for the display weather activity
            */
            Intent i = intentWithValues(xmlTEXT);
            StartActivity(i);
        }

        protected XmlDocument getFormattedXml(string url)
        {
        /** 
            uses the API url to get the response of the weather open weather API and format the response into an XML document
            */
            using (WebClient webClient = new WebClient())
            {
                string responseXML = webClient.DownloadString(url);
                XmlDocument xml_doc = new XmlDocument();
                xml_doc.LoadXml(responseXML);
                return xml_doc;
            }
        }
        protected Intent intentWithValues(XmlDocument xml)
        {
            /**
            Method that takes the values from the API xml response file from the open weather API call
            setting values to intent such as, weather descriptions, sun rise, sun set and temperature
            returns an intent with values in to be sent to the activity that is responsible for displaying the values
            */
            var i = new Intent(this, typeof(DisplayWeather));
            XmlNode node = xml.SelectSingleNode("//city");
            i.PutExtra("SearchTown", node.Attributes["name"].Value);
            node = xml.SelectSingleNode("//sun");
            i.PutExtra("SunRise", node.Attributes["rise"].Value);
            i.PutExtra("SunSet", node.Attributes["set"].Value);
            node = xml.SelectSingleNode("//temperature");
            i.PutExtra("CurrentTemperature", Convert.ToDouble(node.Attributes["value"].Value));
            node = xml.SelectSingleNode("//weather");
            i.PutExtra("WeatherType", node.Attributes["value"].Value);
            i.PutExtra("WeatherIcon", node.Attributes["icon"].Value);
            return i;
        }

        protected string getPreferences()
        {
            /**
            get user stored preference for home town
            */
            var prefs = Application.Context.GetSharedPreferences(Application.PackageName, FileCreationMode.Private);
            return prefs.GetString("homeTown",string.Empty);
        }
    }
}