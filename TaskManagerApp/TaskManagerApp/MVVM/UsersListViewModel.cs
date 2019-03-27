using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TaskManagerApp.Pages;

namespace TaskManagerApp.MVVM
{
    public class UsersListViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<UsersViewModel> UsersList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateUserCommand { protected set; get; }
        public ICommand SaveUserCommand { protected set; get; }
        public ICommand DeleteUserCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        UsersViewModel selectedUser;

        public INavigation Navigation { get; set; }

        public UsersListViewModel()
        {
            UsersList = new ObservableCollection<UsersViewModel>();
            CreateUserCommand = new Command(CreateUser);
            SaveUserCommand = new Command(SaveUser);
            DeleteUserCommand = new Command(DeleteUser);
            BackCommand = new Command(Back);
        }

        public UsersViewModel SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if(selectedUser != value)
                {
                    UsersViewModel tempUser = value;
                    selectedUser = null;
                    OnPropertyChanged("SelectedUser");
                    Navigation.PushAsync(new UserPage(tempUser));
                }
            }

        }

        protected void OnPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void CreateUser()
        {
            Navigation.PushAsync(new UserPage(new UsersViewModel() { ListViewModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveUser(object userObj)
        {
            UsersViewModel userS = userObj as UsersViewModel;
            if( (userS != null) && userS.isValid() )
            {
                UsersList.Add(userS);
            }
            Back();
        }

        private void DeleteUser(object userObj)
        {
            UsersViewModel userD = userObj as UsersViewModel;
            if(userD != null)
            {
                UsersList.Remove(userD);
            }
            Back();
        }
    }
}
