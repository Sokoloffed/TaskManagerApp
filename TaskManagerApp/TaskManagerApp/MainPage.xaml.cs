using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Refit;
using MvvmHelpers;
using TaskManagerApp.Serivces;
using Xamarin.Forms.Xaml;
using TaskManagerApp.Pages;

namespace TaskManagerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {

        public Users user;
        
        public MainPage(Users loggedUser)
        {
            this.user = loggedUser;
            InitializeComponent();
                        
            this.Children.Add(new TasksPage(this.user){ Title = "Tasks tab"});
            this.Children.Add(new UsersPage(this.user) { Title="Users tab"});
            this.Children.Add(new BranchesPage (this.user){ Title = "Branches tab" });             
           
        }

        
    }
}
