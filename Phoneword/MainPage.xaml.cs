using System;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        //Creates a string variable for translatedNumber
        string translatedNumber;

        public MainPage()
        {
            //Initiallises the app
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            //Runs code inside translator file to translate the input into numbers.
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            //If The user has input datat
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                //Allow the call button to appear
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                //Else, do nothing
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
        //Function that acts upon the call button being pressed
        async void OnCall(object sender, EventArgs e)
        {
            //Disoplays call or not alert screen
            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                //If the call buton is pressed at the number to the call history page.
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    App.PhoneNumbers.Add(translatedNumber);
                    callHistoryButton.IsEnabled = true;
                    dialer.Dial(translatedNumber);
                }
            }

        }

        async void OnCallHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallHistoryPage());
        }
    }
}