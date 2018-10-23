using MereNear.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class LoginPage : ContentPage
    {
        public ObservableCollection<CountryCodeModel> CountryData = new ObservableCollection<CountryCodeModel>();
        public LoginPage()
        {
            InitializeComponent();
            GetCountryCode();
        }
        private void GetCountryCode()
        {
            CountryData = new ObservableCollection<CountryCodeModel>()
            {
                new CountryCodeModel { CountryName = "India", CountryCode = "+91" },
                new CountryCodeModel { CountryName = "Pakistan", CountryCode = "+92" },
                new CountryCodeModel { CountryName = "USA", CountryCode = "+1" }
            };
            pickerCountryCode.ItemsSource = CountryData;
        }
    }
}
