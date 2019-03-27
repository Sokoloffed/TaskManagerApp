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
            this.BindingContext = new UsersListViewModel() { Navigation = this.Navigation };

		}
    }
}