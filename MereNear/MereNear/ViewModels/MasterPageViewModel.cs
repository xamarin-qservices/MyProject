﻿using Acr.UserDialogs;
using MereNear.Model;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
    public class MasterPageViewModel : BindableBase
    {
        #region Private Variables
        private readonly INavigationService _navigationService;

        private bool _isPresented;
        private MasterMenuModel _selectedItem;
        #endregion

        #region Public Variables
        public ObservableCollection<MasterMenuModel> MasterMenuListData = new ObservableCollection<MasterMenuModel>();

        public bool IsPresented
        {
            get { return _isPresented; }
            set { SetProperty(ref _isPresented, value); }
        }

        public MasterMenuModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                if (_selectedItem == null)
                {
                    return;
                }
                else
                {
                    if (SelectedItem.MasterMenuLabel == "Home")
                    {
                        _navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Relative));
                    }
                    if (SelectedItem.MasterMenuLabel == "Profile")
                    {
                        _navigationService.NavigateAsync(new Uri("NavigationPage/ProfilePage", UriKind.Relative));
                    }
                    if (SelectedItem.MasterMenuLabel == "Change Language")
                    {
                        _navigationService.NavigateAsync(new Uri("NavigationPage/LanguagePage", UriKind.Relative));
                    }
                    if (SelectedItem.MasterMenuLabel == "Rate Us")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "How Mere Near Work")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "Privacy Policy")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "Terms and Conditions")
                    {
                        _navigationService.NavigateAsync(new Uri("/NavigationPage/TermConditionPage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "Support/Complaints")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "About Us")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                }
            }
        }
        #endregion

        #region Command
        public ICommand LogoutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.NavigateAsync(nameof(LoginPage), null, null, true);
                });
            }
        }
        #endregion

        #region Constructor
        public MasterPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //GetMasterMenuList();
        }
        #endregion

        #region Private Methods
        private void GetMasterMenuList()
        {
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "home.png",
                MasterMenuLabel = "Home"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "profile.png",
                MasterMenuLabel = "Profile"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "language.png",
                MasterMenuLabel = "Change Language"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "home.png",
                MasterMenuLabel = "Rate Us"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "youtube.png",
                MasterMenuLabel = "How Mere Near Work"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "home.png",
                MasterMenuLabel = "Privacy Policy"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "home.png",
                MasterMenuLabel = "Terms and Conditions"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "home.png",
                MasterMenuLabel = "Support/Complaints"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "about.png",
                MasterMenuLabel = "About Us"
            });
            //MasterMenuListData1 = MasterMenuListData;
            //for (int i = 0; i < 5; i++)
            //{
            //    MasterMenuListData.Add(new MasterMenuModel
            //    {
            //        MasterMenuIcon = "home.png",
            //        MasterMenuLabel = "Home"
            //    });
            //}
        }
        #endregion
    }
}
