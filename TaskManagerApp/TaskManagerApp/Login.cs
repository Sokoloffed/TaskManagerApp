using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TaskManagerApp
{
    public class Login : ContentPage
    {
        TableView tableView;

        public Login()
        {
            Title = "Login page";
            Button logButton = new Button
            {
                Text = "Login",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            tableView = new TableView
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
            };
            logButton.Clicked += LogButton_Clicked;
            Content = new StackLayout{ Children = { tableView, logButton } };
        }

        private async void LogButton_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new NavigationPage(new MainPage()));
        }
    }
}