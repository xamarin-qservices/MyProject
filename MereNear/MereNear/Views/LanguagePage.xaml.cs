using MereNear.Model;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class LanguagePage : ContentPage
    {
        public ObservableCollection<LanguageModel> Languages = new ObservableCollection<LanguageModel>();
        public LanguagePage()
        {
            InitializeComponent();
            GetLanguages();
        }

        private void GetLanguages()
        {
            Languages = new ObservableCollection<LanguageModel>()
            {
                new LanguageModel { DisplayName =  "English", ShortName = "en" },
                new LanguageModel { DisplayName =  "Hindi", ShortName = "hi" }
            };
            PickerLanguages.ItemsSource = Languages;
        }
    }
}
