using Acr.UserDialogs;
using MereNear.Localization;
using MereNear.Model;
using MereNear.Resources;
using MereNear.Views;
using Plugin.Multilingual;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class LanguagePageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        private LanguageModel _languageSelected;
        #endregion

        #region Public Variable
        public int a;
        
        public LanguageModel LanguageSelected
        {
            get { return _languageSelected; }
            set
            {
                SetProperty(ref _languageSelected, value);
                if(LanguageSelected == null)
                {
                    return;
                }
                else
                {
                    var language = LanguageSelected;

                    try
                    {
                        DependencyService.Get<ILocalize>().ChangeLocale("hi");
                        App.CultureCode = "hi";

                        //var culture = new CultureInfo(language.ShortName);
                        //AppResources.Culture = culture;
                        //CrossMultilingual.Current.CurrentCultureInfo = culture;
                        UserDialogs.Instance.ShowLoading("Loading");
                        _navigationService.NavigateAsync(new Uri("/NavigationPage/LoginPage", UriKind.Relative), null, true);
                        UserDialogs.Instance.HideLoading();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        #endregion

        #region Command
        public ICommand CorrectTickCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    //_navigationService.NavigateAsync(nameof(LoginPage));
                    try
                    {
                        if (a == 1)
                        {
                            a++;
                            UserDialogs.Instance.ShowLoading("Loading");
                            await Task.Delay(1000);
                            await _navigationService.NavigateAsync(new Uri("/NavigationPage/LoginPage", UriKind.Relative), null, true);
                            UserDialogs.Instance.HideLoading(); 
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Ex:- Exception on going to Login Page:" + ex.Message);
                        UserDialogs.Instance.HideLoading();
                    }
                });
            }
        }
        #endregion

        #region Constructor
        public LanguagePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            a = 1;
            
        }
        #endregion

        #region Private Methods
        
        #endregion
    }
}
