﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TaskManagerApp.Pages;
using TaskManagerApp.Services;

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

        public UsersListViewModel()//(ObservableCollection<UsersViewModel> uc)
        {
            UsersList = new ObservableCollection<UsersViewModel>();
            //UsersList = uc;
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

        private async void SaveUser(object userObj)
        {
            UsersViewModel userS = userObj as UsersViewModel;
            if( (userS != null) && userS.isValid() )
            {
                bool postRes = false;
                UsersService us = new UsersService();
                postRes = await us.PostUserAsync(userS.user);//us.PostUserSync(userS.user);
                if (postRes)
                    UsersList.Add(userS);
            }
            Back();
        }

        private async void DeleteUser(object userObj)
        {
            UsersViewModel userD = userObj as UsersViewModel;
            if(userD != null && userD.isValid())
            {
                bool delRes = false;
                UsersService us = new UsersService();
                delRes = await us.DeleteUserAsync(userD.user);
                if (delRes)
                    UsersList.Remove(userD);
            }
            Back();
        }

    }
}
