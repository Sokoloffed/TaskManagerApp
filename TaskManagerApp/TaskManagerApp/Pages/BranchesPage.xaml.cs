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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            branchesList.BranchesList.Clear();
            BranchesService bs = new BranchesService();
            branchSource = await bs.GetBranches();
            foreach(Branches branch in branchSource)
            {
                BranchesViewModel bvm = new BranchesViewModel
                {
                    id = branch.id,
                    branchname = branch.branchname,
                    description = branch.description,
                    creator_id = branch.creator_id,
                    created_date = branch.created_date
                };
                branchesList.BranchesList.Add(bvm);

            }

        }

        /*protected override async void OnAppearing()
        {
            base.OnAppearing();
            BranchesService bs = new BranchesService();
            branchSource = await bs.GetBranches();
            branchModels = new ObservableCollection<BranchesViewModel>();
            branchesList.BranchesList = new ObservableCollection<BranchesViewModel>();
            foreach(Branches branch in branchSource)
            {
                BranchesViewModel bvm = new BranchesViewModel
                {
                    id = branch.id,
                    branchname = branch.branchname,
                    description = branch.description,
                    creator_id = branch.creator_id,
                    created_date = branch.created_date
                };
                branchesList.BranchesList.Add(bvm);
            }
        }*/
    }
}