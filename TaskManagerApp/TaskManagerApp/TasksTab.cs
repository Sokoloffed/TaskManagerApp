using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TaskManagerApp.Pages
{
    public class TasksTab : ContentPage
    {
        public TasksTab()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Tasks Page" }
                }
            };
        }
    }
}