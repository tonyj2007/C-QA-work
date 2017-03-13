using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android.Content;

namespace WeatherApp3
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
        protected override void OnResume()
        {
            /*
            Splash screen them assigned to a thread and delayed before redirecting to the home page
            */
            base.OnResume();
            Task startWork = new Task(() =>
            {
                Task.Delay(4000);
            });

            startWork.ContinueWith(t =>
            {
                StartActivity(new Intent(Application.Context, typeof(HomeActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startWork.Start();
        }
    }
}

