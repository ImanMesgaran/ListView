using Prism;
using Prism.Ioc;
using ListView.ViewModels;
using ListView.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ListView
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

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MyMasterDetailPage/MyNavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Containers
            containerRegistry.RegisterForNavigation<MyMasterDetailPage>();
            containerRegistry.RegisterForNavigation<MyNavigationPage>();
            
            // Pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<MainListView,MainListViewViewModel>();
            containerRegistry.RegisterForNavigation<SubListView,SubListViewViewModel>();
        }
    }
}
