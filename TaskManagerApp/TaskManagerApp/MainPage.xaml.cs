using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TaskManagerApp
{
    public partial class MainPage : ContentPage
    {
        public List<Users> usersss { get; set; }

        ObservableCollection<Users> usersobsv;
        IEnumerable<Users> users;
        Service service;
        string response = "";

        public static async Task<ObservableCollection<Users>> getUsers()
        {
            try
            {
                var result = new ObservableCollection<Users>();
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        RequestUri = new Uri("http://10.0.2.2:50368/api/Users/Get"),
                        Method = HttpMethod.Get
                    };

                    request.Headers.Add("Accept", "application/json");
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var myObj = JsonConvert.DeserializeObject<ObservableCollection<Users>>(json);
                        if (!Equals(myObj, null))
                            result = myObj;
                    }
                    else
                    {
                        Debug.WriteLine(response.StatusCode);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }

        }

        public async void InvokeGetUsers()
        {
            ObservableCollection<Users> us = await getUsers();
            
            this.usersobsv = await getUsers();
        }

        public MainPage()
        {

            InvokeGetUsers();
            //var t = Task.Run(() => getUsersString(new Uri("http://localhost:50368/api/Users/Get")));
            //t.Wait();
            Label header = new Label
            {
                Text = "List of users",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            /*mock = user;/*new List<Users>
            {
                new Users{id = 1, username = "vasya", password = "kolya"},
                new Users{id = 2, username="petya", password="vasyahuy"},
                new Users{id=15, username="poroh", password="sladko"},
                new Users{id=152,username ="vova", password="95ave"}
            };*/
            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = users,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label uid = new Label { FontSize = 20 };
                    uid.SetBinding(Label.TextProperty, "id");

                    Label uname = new Label { FontSize = 20 };
                    uname.SetBinding(Label.TextProperty, "username");

                    Label upas = new Label { FontSize = 18 };
                    upas.SetBinding(Label.TextProperty, "password");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(5, 10),
                            Orientation = StackOrientation.Vertical,
                            Children = { uid, uname, upas }
                        }
                    };
                })
            };
            //Button button = new Button();
            this.Content = new StackLayout { Children = { header, listView } };
            
        }

        
    }
}
