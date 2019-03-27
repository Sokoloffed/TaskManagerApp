using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagerApp.Services;
using Xamarin.Forms;

namespace TaskManagerApp
{
    public class Login : ContentPage
    {
        TableView tableView;

        Entry unameE;
        Entry upasE;
        Users user;

        public Login()
        {
            this.user = new Users();
            Title = "Login page";
            unameE = new Entry
            {
                Text = "Ba"
            };
            upasE = new Entry
            {
                Text = "Sya"
            };
            Button logButton = new Button
            {
                Text = "Login",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            
            Button createButton = new Button
            {
                Text = "Create new user",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            logButton.Clicked += LogButton_Clicked;
            createButton.Clicked += createButton_Clicked;
            Content = new StackLayout{ Children = { unameE, upasE, createButton, logButton } };
        }

        private async void createButton_Clicked(object sender, EventArgs e)
        {
            string name = unameE.Text;
            string pas = upasE.Text;
            UsersService us = new UsersService();
            Users newUser = new Users
            {
                id = 1000,
                username = name,
                password = pas
            };
            bool isCreated = await us.PostUser(newUser);
            if (isCreated)
            {
                await Navigation.PushAsync(new MainPage(newUser));
            }
        }

        private async void LogButton_Clicked(object sender, EventArgs e)
        {
            string name = unameE.Text;
            string pas = upasE.Text;
            UsersService us = new UsersService();
            user = await us.GetUser(name, pas);
            if(user != null)
            {
                await Navigation.PushAsync(new MainPage(user));
            }
        }
    }
}

/*tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Login")
                {
                    new TableSection("Please, log in to continue")
                    {
                        new EntryCell
                        {
                            Label = "Enter your login",
                            Placeholder = "Print here...",
                            Keyboard = Keyboard.Default
                        },
                        new EntryCell
                        {
                            Label = "Enter your password",
                            Placeholder = "Print here...",
                            Keyboard = Keyboard.Default
                        }
                    }
                }
            };*/
