using Prism;
using Prism.Ioc;
using MereNear.ViewModels;
using MereNear.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using MereNear.Views.Common;
using DLToolkit.Forms.Controls;
using MereNear.Services.ApiService.Common;
using Plugin.Multilingual;
using MereNear.Resources;
using MereNear.Localization;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MereNear
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        public static string CultureCode { get; set; }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            FlowListView.Init();
            DependencyService.Get<ILocalize>().SetLocale();
            App.CultureCode = string.Empty;

            await NavigationService.NavigateAsync("NavigationPage/LanguagePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IWebApiRestClient, WebApiRestClient>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LanguagePage, LanguagePageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SignupPage, SignupPageViewModel>();
            containerRegistry.RegisterForNavigation<SendOtpPage, SendOtpPageViewModel>();
            containerRegistry.RegisterForNavigation<TermConditionPage, TermConditionPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
            containerRegistry.RegisterForNavigation<PostPage, PostPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<RequestRecieved, RequestRecievedViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<HomeDetailPage, HomeDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<PlumberDetail, PlumberDetailViewModel>();
            containerRegistry.RegisterForNavigation<MasterPage, MasterPageViewModel>();
        }
    }
}
