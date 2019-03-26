using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using MvvmHelpers;
using TaskManagerApp.Serivces;
using System.Threading.Tasks;

namespace TaskManagerApp.Pages
{
	public class Tab2 : ContentPage
	{
        private readonly ApiClient apiClient;
        public ObservableRangeCollection<Users> UsersSource { get; set; }
        List<string> Users;


        public Tab2 ()
		{
            BindingContext = this;

            UsersSource = new ObservableRangeCollection<Users>();
            //apiClient = new ApiClient("");
            Users = new List<string>();

            //Task.Factory.StartNew(RequestData);

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Tab2" }
                }
            
			};
		}

        private async Task RequestData()
        {
            //var t = await apiClient.GetService();

            //await Task.Delay(500);
            ObservableRangeCollection<Users> mock = new ObservableRangeCollection<Users>();
           // mock = await apiClient.GetUsers();
            

            UsersSource.ReplaceRange(mock);
            OnPropertyChanged(nameof(UsersSource));
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
