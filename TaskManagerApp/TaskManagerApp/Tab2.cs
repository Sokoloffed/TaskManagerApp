using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using MvvmHelpers;
using TaskManagerApp.Serivces;
using System.Threading.Tasks;
using TaskManagerApp.Services;

namespace TaskManagerApp.Pages
{
	public class Tab2 : ContentPage
	{
        public IEnumerable<Users> UsersSource { get; set; }



        public Tab2 ()
		{
            //BindingContext = this;
            //ObservableRangeCollection
            //UsersSource = new IEnumerable<Users>();
            Label label = new Label
            {
                Text = "List of users"
            };
            //Task.WaitAll();
            //RequestData();

            ListView listView = new ListView();
            List<string> names = new List<string>();
            Task.Factory.StartNew(() => RequestData());
            //RequestData();
            foreach (var user in UsersSource)
            {
                names.Add(user.username);
            }
            listView.ItemsSource = names;
            this.Content = new StackLayout { Children = { label, listView} };
		}

        private async void RequestData()
        {
            //var t = await apiClient.GetService();
            UsersService us = new UsersService();
            IEnumerable<Users> users = await us.GetUsers();
            UsersSource = users;
            //IEnumerable<Users> mock = new IEnumerable<Users>();
            //mock = await us.GetUsers();
            //UsersSource.ReplaceRange(mock);
            //OnPropertyChanged(nameof(UsersSource));
        }

	}
}


/*
 * <ListView ItemsSource="{Binding UsersSource}"
                  HorizontalOptions="FillAndExpand"
                  VerticalOptions="FillAndExpand">
        <ListView.Header>
            <StackLayout>
                <Label Text="List of users" FontSize="Large"></Label>
            </StackLayout>
        </ListView.Header>
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <StackLayout Padding="5,10">
                        <Label FontSize="Large" Text="{Binding Id}"></Label>
                        <Label FontSize="Large" Text="{Binding Username}"></Label>
                        <Label FontSize="Large" Text="{Binding Password}"></Label>
                    </StackLayout>
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
    from MainPage.xaml
 */
