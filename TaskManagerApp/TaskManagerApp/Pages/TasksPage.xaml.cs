using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.MVVM;
using TaskManagerApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaskManagerApp.Services;

namespace TaskManagerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TasksPage : ContentPage
	{
        ObservableCollection<Tasks> tasksSource;
        ObservableCollection<TasksViewModel> tasksModels;
        TasksListViewModel tasksList;
        Users t_user;

		public TasksPage (Users user)
		{
			InitializeComponent ();
            this.t_user = user;
            tasksList = new TasksListViewModel { Navigation = this.Navigation };
            this.BindingContext = tasksList;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            TaskService ts = new TaskService();
            tasksSource = await ts.GetTasksCreator(this.t_user.id);
            foreach(Tasks t in tasksSource)
            {
                TasksViewModel tvm = new TasksViewModel
                {
                    id = t.id,
                    taskname = t.taskname,
                    description = t.description,
                    date_begin = t.date_begin,
                    date_end = t.date_end,
                    status = t.status,
                    creator_id = t.creator_id,
                    executor_id = t.executor_id
                };
                tasksList.TasksList.Add(tvm);
            }

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            TaskService ts = new TaskService();
            tasksSource = await ts.GetTasksExecutor(this.t_user.id);
            foreach(Tasks t in tasksSource)
            {
                TasksViewModel tvm = new TasksViewModel
                {
                    id = t.id,
                    taskname = t.taskname,
                    description = t.description,
                    date_begin = t.date_begin,
                    date_end = t.date_end,
                    status = t.status,
                    creator_id = t.creator_id,
                    executor_id = t.executor_id
                };
                tasksList.TasksList.Add(tvm);
            }
        }
    }
}