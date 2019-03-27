using System;
using System.Collections.Generic;
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
        IEnumerable<Users> usersSource;
		public UsersPage ()
		{
			InitializeComponent ();

		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            UsersService us = new UsersService();
            usersSource = await us.GetUsers();

            this.BindingContext = new List<UsersViewModel>();


        }
    }
}