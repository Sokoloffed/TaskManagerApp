using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        Users delegateUser;
        Branches delegateBranch;

		public TaskPage (TasksViewModel task, Users user)
		{
            
			InitializeComponent ();
            this.curr_user = user;
            this.ViewModel = task;
            this.BindingContext = ViewModel;
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new AddTaskUserPage(this.ViewModel));
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {

        }
    }
}