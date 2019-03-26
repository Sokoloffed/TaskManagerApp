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

        string username;
        string password;
        Users user;
        EntryCell usernameEC;
        EntryCell passwordEC;

        public Login()
        {
            this.username = String.Empty;
            this.password = String.Empty;
            this.user = new Users();
            Title = "Login page";
            usernameEC = new EntryCell
            {
                Label = "Enter username",
                Placeholder = "...",
                Keyboard = Keyboard.Default
            };
            passwordEC = new EntryCell
            {
                Label = "Enter username",
                Placeholder = "...",
                Keyboard = Keyboard.Default
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
            Content = new StackLayout{ Children = { tableView, logButton } };
        }

        private async void createButton_Clicked(object sender, EventArgs e)
        {
            UsersService us = new UsersService();
            Users newUser = new Users
            {
                Id = 1000,
                Username = usernameEC.Placeholder.ToString(),
                Password = passwordEC.Placeholder.ToString()
            };
            bool isCreated = await us.PostUser(newUser);
            if (isCreated)
            {
                await Navigation.PushAsync(new MainPage(newUser));
            }
        }

        private async void LogButton_Clicked(object sender, EventArgs e)
        {
            this.username = usernameEC.Placeholder.ToString();
            this.password = passwordEC.Placeholder.ToString();
            UsersService us = new UsersService();
            user = await us.GetUser(this.username, this.password);
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
