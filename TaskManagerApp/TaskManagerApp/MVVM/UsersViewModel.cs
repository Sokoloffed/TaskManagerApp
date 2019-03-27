﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TaskManagerApp.MVVM
{
    public class UsersViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        UsersListViewModel ulvm;
        public Users user { get; set; }

        public UsersViewModel()
        {
            user = new Users();
        }

        public UsersListViewModel ListViewModel
        {
            get { return ulvm; }
            set
            {
                if (ulvm != value)
                {
                    ulvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }

        }

        public bool isValid()
        {
            return (!string.IsNullOrEmpty(username.Trim()) ||
                (!string.IsNullOrEmpty(password.Trim())));
        }

        public int id
        {
            get { return user.id; }
            set
            {
                if (user.id != value)
                {
                    user.id = value;
                    OnPropertyChanged("id");
                }
            }
        }

        public string username
        {
            get { return user.username; }
            set
            {
                if(user.username != value)
                {
                    user.username = value;
                    OnPropertyChanged("username");
                }
            }
        }

        public string password
        {
            get { return user.password; }
            set
            {
                if(user.password != value)
                {
                    user.password = value;
                    OnPropertyChanged("password");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}