using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaskManagerApp.MVVM
{
    class UsersListViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<UsersViewModel> UsersList { get; set; }

        public event ProgressChangedEventHandler PropertyChanged;

        public ICommand CreateUserCommand { protected set; get; }
        public ICommand SaveUserCommand { protected set; get; }
        public ICommand DeleteUserCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        UsersViewModel selectedUser;

        public INavigation Navigation { get; set; }
    }
}
