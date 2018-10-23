using Acr.UserDialogs;
using MereNear.Model;
using MereNear.Resources;
using MereNear.Services.ApiService.Common;
using MereNear.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class HomePageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        protected readonly IWebApiRestClient _webApiRestClient;

        private Color _lookingJobButtonColor = Color.Transparent;
        private Color _lookingJobButtonTextColor = Color.Gray;

        private Color _postJobButtonTextColor = Color.White;
        private Color _postJobButtonColor = Color.FromHex("#3B92E7");

        private Color _myJobsBGColor = Color.Transparent;
        private Color _myPostsBGColor = Color.Transparent;
        private Color _messagesBGColor = Color.Transparent;
        private Color _notificationsBGColor = Color.Transparent;

        private Color _myJobsLabelColor = Color.Black;
        private Color _myPostsLabelColor = Color.Black;
        private Color _messagesLabelColor = Color.Black;
        private Color _notificationsLabelColor = Color.Black;

        private ImageSource _myJobsIcon = "post_job.png";   //Change icon
        private ImageSource _myPostsIcon = "my_post.png";
        private ImageSource _messagesIcon = "message.png";
        private ImageSource _notificationsIcon = "notification.png";

        private string _titleText;
        private string _headerLeft2ndIcon;

        private HomePageModel _categorySelectedItem;
        #endregion

        #region Public Variables
        public ObservableCollection<HomePageModel> NewCategoryData = new ObservableCollection<HomePageModel>();

        public Color LookingJobButtonColor
        {
            get { return _lookingJobButtonColor; }
            set { SetProperty(ref _lookingJobButtonColor, value); }
        }

        public Color LookingJobButtonTextColor
        {
            get { return _lookingJobButtonTextColor; }
            set { SetProperty(ref _lookingJobButtonTextColor, value); }
        }

        public Color PostJobButtonColor
        {
            get { return _postJobButtonColor; }
            set { SetProperty(ref _postJobButtonColor, value); }
        }

        public Color PostJobButtonTextColor
        {
            get { return _postJobButtonTextColor; }
            set { SetProperty(ref _postJobButtonTextColor, value); }
        }

        public Color MyJobsBGColor
        {
            get { return _myJobsBGColor; }
            set { SetProperty(ref _myJobsBGColor, value); }
        }

        public Color MyPostsBGColor
        {
            get { return _myPostsBGColor; }
            set { SetProperty(ref _myPostsBGColor, value); }
        }

        public Color MessagesBGColor
        {
            get { return _messagesBGColor; }
            set { SetProperty(ref _messagesBGColor, value); }
        }

        public Color NotificationsBGColor
        {
            get { return _notificationsBGColor; }
            set { SetProperty(ref _notificationsBGColor, value); }
        }

        public Color MyJobsLabelColor
        {
            get { return _myJobsLabelColor; }
            set { SetProperty(ref _myJobsLabelColor, value); }
        }

        public Color MyPostsLabelColor
        {
            get { return _myPostsLabelColor; }
            set { SetProperty(ref _myPostsLabelColor, value); }
        }

        public Color MessagesLabelColor
        {
            get { return _messagesLabelColor; }
            set { SetProperty(ref _messagesLabelColor, value); }
        }

        public Color NotificationsLabelColor
        {
            get { return _notificationsLabelColor; }
            set { SetProperty(ref _notificationsLabelColor, value); }
        }

        public ImageSource MyJobsIcon
        {
            get { return _myJobsIcon; }
            set { SetProperty(ref _myJobsIcon, value); }
        }

        public ImageSource MyPostsIcon
        {
            get { return _myPostsIcon; }
            set { SetProperty(ref _myPostsIcon, value); }
        }

        public ImageSource MessagesIcon
        {
            get { return _messagesIcon; }
            set { SetProperty(ref _messagesIcon, value); }
        }

        public ImageSource NotificationsIcon
        {
            get { return _notificationsIcon; }
            set { SetProperty(ref _notificationsIcon, value); }
        }
        
        public string TitleText
        {
            get { return _titleText; }
            set { SetProperty(ref _titleText, value); }
        }

        public string HeaderLeft2ndIcon
        {
            get { return _headerLeft2ndIcon; }
            set { SetProperty(ref _headerLeft2ndIcon, value); }
        }
        #endregion

        #region Command
        public ICommand PostJobCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    PostJobButtonColor = Color.FromHex("#3B92E7");
                    PostJobButtonTextColor = Color.White;
                    LookingJobButtonColor = Color.Transparent;
                    LookingJobButtonTextColor = Color.Gray;
                });
            }
        }

        public ICommand LookingJobCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        LookingJobButtonColor = Color.FromHex("#3B92E7");
                        LookingJobButtonTextColor = Color.White;
                        PostJobButtonColor = Color.Transparent;
                        PostJobButtonTextColor = Color.Gray;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Ex:- Exception on going to Home Page:" + ex.Message);
                        UserDialogs.Instance.HideLoading();
                    }
                });
            }
        }

        public ICommand PlumberCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading("Loading");
                        await Task.Delay(1000);
                        await _navigationService.NavigateAsync(nameof(HomeDetailPage), null, null, true);
                        UserDialogs.Instance.HideLoading();
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                });
            }
        }

        public ICommand MyJobsTabCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Application.Current.Properties["TabClicked"] = "MyJobsTab";
                    ClearTab();
                    SelectedTab();
                });
            }
        }

        public ICommand MyPostsTabCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Application.Current.Properties["TabClicked"] = "MyPostsTab";
                    ClearTab();
                    SelectedTab();
                });
            }
        }

        public ICommand MessagesTabCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Application.Current.Properties["TabClicked"] = "MessagesTab";
                    ClearTab();
                    SelectedTab();
                });
            }
        }

        public ICommand NotificationsTabCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Application.Current.Properties["TabClicked"] = "NotificationsTab";
                    ClearTab();
                    SelectedTab();
                });
            }
        }

        public ICommand HeaderLeftIconCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MessagingCenter.Send("HamburgurClick", "OpenMasterDetailPage");
                });
            }
        }

        public ICommand HeaderLeft2ndIconCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ClearTab();
                });
            }
        }

        public ICommand ListViewCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    
                });
            }
        }
        #endregion

        #region Constructor
        public HomePageViewModel(INavigationService navigationService, IWebApiRestClient webApiRestClient)
        {
            _navigationService = navigationService;
            _webApiRestClient = webApiRestClient;

            ClearTab();
            MessagingCenter.Subscribe<object>(this, "WorkerDetailPage", (sender) =>
            {
                var result = (HomePageModel)sender;
                if (result.CategoryName == "Plumber")
                {
                    _navigationService.NavigateAsync("/NavigationPage/HomeDetailPage");
                }
            });

        }
        #endregion

        #region Private Methods
        private void ClearTab()
        {
            MyJobsBGColor = Color.Transparent;
            MyPostsBGColor = Color.Transparent;
            MessagesBGColor = Color.Transparent;
            NotificationsBGColor = Color.Transparent;

            MyJobsLabelColor = Color.Black;
            MyPostsLabelColor = Color.Black;
            MessagesLabelColor = Color.Black;
            NotificationsLabelColor = Color.Black;

            MyJobsIcon = "post_job.png";
            MyPostsIcon = "my_post.png";
            MessagesIcon = "message.png"; 
             NotificationsIcon = "notification.png";

            TitleText = AppResources.HomePageTitle;
            HeaderLeft2ndIcon = "";
        }

        private void SelectedTab()
        {
            HeaderLeft2ndIcon = "homewhite.png";
            if (Application.Current.Properties["TabClicked"].ToString() == "MyJobsTab")
            {
                Application.Current.Properties.Remove("TabClicked");
                MyJobsBGColor = Color.FromHex("#3B92E7");
                MyJobsLabelColor = Color.White;
                MyJobsIcon = "post_job_selected.png";
                TitleText = AppResources.MyJobsTab;
                return;
            }
            if (Application.Current.Properties["TabClicked"].ToString() == "MyPostsTab")
            {
                Application.Current.Properties.Remove("TabClicked");
                MyPostsBGColor = Color.FromHex("#3B92E7");
                MyPostsLabelColor = Color.White;
                MyPostsIcon = "my_post_select.png";
                TitleText = AppResources.MyPostsTab;
                return;
            }
            if (Application.Current.Properties["TabClicked"].ToString() == "MessagesTab")
            {
                Application.Current.Properties.Remove("TabClicked");
                MessagesBGColor = Color.FromHex("#3B92E7");
                MessagesLabelColor = Color.White;
                MessagesIcon = "message.png";
                TitleText = AppResources.MessagesTab;
                return;
            }
            if (Application.Current.Properties["TabClicked"].ToString() == "NotificationsTab")
            {
                Application.Current.Properties.Remove("TabClicked");
                NotificationsBGColor = Color.FromHex("#3B92E7");
                NotificationsLabelColor = Color.White;
                NotificationsIcon = "notification_selected.png";
                TitleText = AppResources.NotificationsTab;
                return;
            }
        }
        #endregion

        #region ApiMethod
        public async void GetCategoryApi()
        {
            try
            {
                var result = await _webApiRestClient.GetAsync<GetCatApiModel>("?func=getcat");
                NewCategoryData = new ObservableCollection<HomePageModel>(result.data);
            }
            catch (WebException ex)
            {
                UserDialogs.Instance.Alert(ex.Message);
            }
        }
        #endregion
    }
}