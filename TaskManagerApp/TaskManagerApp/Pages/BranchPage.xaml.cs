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
	public partial class BranchPage : ContentPage
	{
        public ObservableCollection<Tasks> branchTasks { get; set; }
        public ObservableCollection<Users> branchUsers { get; set; }

        public BranchesViewModel ViewModel;
        public Users curr_user;

		public BranchPage (BranchesViewModel branch, Users user)
		{
			InitializeComponent ();
            this.curr_user = user;
            this.ViewModel = branch;
            this.BindingContext = ViewModel;
		}
	}
}