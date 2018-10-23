using Acr.UserDialogs;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class SendOtpPageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        private string _otpNumber;
        #endregion

        #region Public Variables
        public int a;

        public string OTPNumber
        {
            get { return _otpNumber; }
            set { SetProperty(ref _otpNumber, value); }
        }
        #endregion

        #region Command
        public ICommand Login_RegisterCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        //if (OTPNumber == Convert.ToString(Application.Current.Properties["OTPNumber"]))
                        //{
                        //await _navigationService.NavigateAsync(nameof(HomePage), null, null, true);
                        await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomePage", UriKind.Absolute));
                        //}
                        //else
                        //{
                        //    UserDialogs.Instance.Alert("You have entered wrong otp");
                        //}
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Ex:- Exception on going to About Page:" + ex.Message);
                    }
                });
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.GoBackAsync();
                });
            }
        }
        #endregion

        #region Constructor
        public SendOtpPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
