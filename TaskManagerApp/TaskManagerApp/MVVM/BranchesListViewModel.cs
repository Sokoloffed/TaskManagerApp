using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TaskManagerApp.Pages;
using TaskManagerApp.Services;
using Xamarin.Forms;

namespace TaskManagerApp.MVVM
{
    public class BranchesListViewModel
    {
        public ObservableCollection<BranchesViewModel> BranchesList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateBranchCommand { protected set; get; }
        public ICommand SaveBranchCommand { protected set; get; }
        public ICommand DeleteBranchCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        public Users curr_user;
        BranchesViewModel selectedBranch;

        public INavigation Navigation { get; set; }

        public BranchesListViewModel(Users user)//(ObservableCollection<UsersViewModel> uc)
        {
            BranchesList = new ObservableCollection<BranchesViewModel>();
            this.curr_user = user;
            //UsersList = uc;
            CreateBranchCommand = new Command(CreateBranch);
            SaveBranchCommand = new Command(SaveBranch);
            DeleteBranchCommand = new Command(DeleteBranch);
            BackCommand = new Command(Back);
        }

        public BranchesViewModel SelectedBranch
        {
            get { return selectedBranch; }
            set
            {
                if (selectedBranch != value)
                {
                    BranchesViewModel tempBranch = value;
                    selectedBranch = null;
                    OnPropertyChanged("SelectedBranch");
                    Navigation.PushAsync(new BranchPage(tempBranch, curr_user));
                }
            }

        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void CreateBranch()
        {
            Navigation.PushAsync(new BranchPage(new BranchesViewModel() { ListViewModel = this}, curr_user));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private async void SaveBranch(object branchObj)
        {
            BranchesViewModel branchS = branchObj as BranchesViewModel;
            if ((branchS != null) && branchS.isValid())
            {
                bool postRes = false;
                BranchesService us = new BranchesService();
                postRes = await us.PostAsync(branchS.branch);//us.PostUserSync(userS.user);
                if (postRes)
                    BranchesList.Add(branchS);
            }
            Back();
        }

        private async void DeleteBranch(object branchObj)
        {
            BranchesViewModel branchD = branchObj as BranchesViewModel;
            if (branchD != null && branchD.isValid())
            {
                bool delRes = false;
                BranchesService us = new BranchesService();
                delRes = await us.DeleteAsync(branchD.branch);
                if (delRes)
                    BranchesList.Remove(branchD);
            }
            Back();
        }

    }
}
