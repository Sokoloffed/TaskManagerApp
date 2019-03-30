using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.MVVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManagerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public ObservableCollection<Tasks> userTasks { get; set; }
        public ObservableCollection<Branches> userBranches { get; set; }

        public UsersViewModel ViewModel { get; set; }

        public UserPage(UsersViewModel user)
        {
            InitializeComponent();
            this.ViewModel = user;
            this.BindingContext = ViewModel;
        }
    }
}