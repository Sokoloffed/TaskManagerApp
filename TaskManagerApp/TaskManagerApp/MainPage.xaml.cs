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
        List<string> Users;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            UsersSource = new ObservableRangeCollection<Users>();
            apiClient = new ApiClient();
            Users = new List<string>();
                       
            Task.Factory.StartNew(RequestData);
        }

        private async Task RequestData()
        {
            //var t = await apiClient.GetService();

            //await Task.Delay(500);
            ObservableRangeCollection<Users> mock = new ObservableRangeCollection<Users>();
            mock = await apiClient.GetUsers();
            

            UsersSource.ReplaceRange(mock);
            OnPropertyChanged(nameof(UsersSource));
        }

    }
}
