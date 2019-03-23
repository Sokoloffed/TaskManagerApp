using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TaskManagerApp.Pages
{
	public class Tab3 : ContentPage
	{
		public Tab3 ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Tab3" }
				}
			};
		}
	}
}