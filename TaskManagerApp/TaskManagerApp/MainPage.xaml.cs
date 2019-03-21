using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaskManagerApp
{
    public partial class MainPage : ContentPage
    {

        p
        public List<Users> users { get; set; }

        public MainPage()
        {
            Label header = new Label
            {
                Text = "List of users",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            users = new List<Users>
            {
                new Users{id = 1, username = "vasya", password = "kolya"},
                new Users{id = 2, username="petya", password="vasyahuy"},
                new Users{id=15, username="poroh", password="sladko"},
                new Users{id=152,username ="vova", password="95ave"}
            };
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
