using Acr.UserDialogs;
using MereNear.Model;
using MereNear.Services.ApiService.Common;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class HomePage : ContentPage
    {
        protected readonly IWebApiRestClient _webApiRestClient;
        
        public HomePage(IWebApiRestClient webApiRestClient)
        {
            InitializeComponent();
            _webApiRestClient = webApiRestClient;
            GetCategoryApi();
        }

        #region ApiMethod
        public async void GetCategoryApi()
        {
            try
            {
                var result = await _webApiRestClient.GetAsync<GetCatApiModel>("?func=getcat");
                homePageData.FlowItemsSource = result.data;
            }
            catch (WebException ex)
            {
                UserDialogs.Instance.Alert(ex.Message);
            }
        }
        #endregion

        private void homePageData_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagingCenter.Send(e.Item, "WorkerDetailPage");
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
