using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.MVVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManagerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BranchesPage : ContentPage
	{
        ObservableCollection<Branches> branchSource;
        ObservableCollection<BranchesViewModel> branchModels;
        BranchesListViewModel branchesList;
        Users curr_user;

        public BranchesPage(Users user)
        {
            InitializeComponent();
            this.curr_user = user;
            branchesList = new BranchesListViewModel(curr_user) { Navigation = this.Navigation };
            this.BindingContext = branchesList;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}