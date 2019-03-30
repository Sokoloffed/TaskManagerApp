using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManagerApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserTasks : ContentPage
	{

        Users user;

        public UserTasks()
        {
            InitializeComponent();
        }

		/*public UserTasks (Users user)
		{
			InitializeComponent ();
            this.user = user;
		}*/
	}
}