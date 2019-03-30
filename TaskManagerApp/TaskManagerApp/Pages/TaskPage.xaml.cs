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
	public partial class TaskPage : ContentPage
	{
        ObservableCollection<Users> users;
        ObservableCollection<Branches> branches;
        Users curr_user;
        TasksViewModel ViewModel;

		public TaskPage (TasksViewModel task, Users user)
		{
            
			InitializeComponent ();
            this.curr_user = user;
            this.ViewModel = task;
            this.BindingContext = ViewModel;
        }
	}
}