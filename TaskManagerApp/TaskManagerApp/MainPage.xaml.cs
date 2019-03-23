using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Refit;
using MvvmHelpers;
using TaskManagerApp.Serivces;
using Xamarin.Forms.Xaml;

namespace TaskManagerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly ApiClient apiClient;
        public ObservableRangeCollection<Users> UsersSource { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            UsersSource = new ObservableRangeCollection<Users>();
            apiClient = new ApiClient();
                       
            Task.Factory.StartNew(RequestData);
        }

        private async Task RequestData()
        {
            //var t = await apiClient.GetService();

            await Task.Delay(500);

            var mock = new Users[]
            {
                new Users()
                {
                    Username = "tmp",
                    Password = "123"
                },
                new Users()
                {
                    Username = "tmp",
                    Password = "123"
                },
                new Users()
                {
                    Username = "tmp",
                    Password = "123"
                },
            };

            UsersSource.ReplaceRange(mock);
            OnPropertyChanged(nameof(UsersSource));
        }

        private async Task CallApi()
        {
            var response = RestService.For<IDBAPi>("http://makeup-api.herokuapp.com");
            var maleUps = await response.GetMakeUps();
        }

    }
}
