using MereNear.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class PostPage : ContentPage
    {
        public ObservableCollection<PostPageModel> newListData = new ObservableCollection<PostPageModel>();
        public PostPage()
        {
            InitializeComponent();
            GetPlumberList();
        }
        private void GetPlumberList()
        {
            for (int i = 0; i < 5; i++)
            {
                newListData.Add(new PostPageModel
                {
                    PlumberName = "Plumber",
                    PlumberTask = "Completed",
                    PlumberTaskDate = "11 Jan. 2017"
                });
            }
            plumberList.ItemsSource = newListData;
        }
    }
}
