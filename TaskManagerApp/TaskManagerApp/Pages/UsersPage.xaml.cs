using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.MVVM;
using TaskManagerApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManagerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        ObservableCollection<Users> usersSource;
        ObservableCollection<UsersViewModel> usersModels;
        UsersListViewModel usersList;
        public UsersPage()
        {
            InitializeComponent();
            usersList = new UsersListViewModel() { Navigation = this.Navigation };
            this.BindingContext = usersList;//new UsersListViewModel() { Navigation = this.Navigation };

		}

        private async  void Button_Clicked(object sender, EventArgs e)
        {
            UsersService us = new UsersService();
            usersSource = await us.GetUsers();
            foreach(Users u in usersSource)
            {
                UsersViewModel uvm = new UsersViewModel
                {
                    id = u.id,
                    username=u.username,
                    password=u.password,
                    user = u,
                    ListViewModel = this.usersList
                };
                usersList.UsersList.Add(uvm);
            }

        }
    }
}