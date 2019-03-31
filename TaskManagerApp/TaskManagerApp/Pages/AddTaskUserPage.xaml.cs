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

namespace TaskManagerApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTaskUserPage : ContentPage
	{
        public TasksViewModel task;
        public ObservableCollection<Users> possibleUsers;
        public UsersListViewModel users_list;

		public AddTaskUserPage (TasksViewModel taskToAdd)
		{
			InitializeComponent ();
            this.task = taskToAdd;
            users_list = new UsersListViewModel(new Users());
            users_list.task_id = this.task.id;
            this.BindingContext = users_list;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            UsersService us = new UsersService();
            this.possibleUsers = await us.GetUsers();
            foreach(Users u in possibleUsers)
            {
                UsersViewModel uvm = new UsersViewModel
                {
                    id = u.id,
                    username = u.username,
                    password = u.username
                };
                users_list.UsersList.Add(uvm);
            }
            //var tuple = Tuple.Create(this.task, this.possibleUsers);
        }
    }
}