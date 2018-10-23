using MereNear.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MereNear.Views.Common
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            GetMasterMenuList();
            MessagingCenter.Subscribe<string>(this, "OpenMasterDetailPage", (sender) => {
                if (!IsPresented)
                    IsPresented = true;
            });
        }

        public ObservableCollection<MasterMenuModel> MasterMenuListData = new ObservableCollection<MasterMenuModel>();
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
            masterMenuList.ItemsSource = MasterMenuListData;
            //for (int i = 0; i < 5; i++)
            //{
            //    MasterMenuListData.Add(new MasterMenuModel
            //    {
            //        MasterMenuIcon = "home.png",
            //        MasterMenuLabel = "Home"
            //    });
            //    masterMenuList.ItemsSource = MasterMenuListData;
            //}
        }

        private void MasterMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            masterMenuList.SelectedItem = null;
        }
    }
}