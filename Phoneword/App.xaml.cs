//This is the main screen this is what is booted up at the start.

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Phoneword
{
    public partial class App : Application
    {
        public static IList<string> PhoneNumbers { get; set; }

        public App()
        {
            //Initialising the app
            InitializeComponent();
            //Creates a list of the phone numbers 
            PhoneNumbers = new List<string>();
            //Sets the main page to MainPage.xaml
            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}