using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TaskManagerApp.Services;
using TaskManagerApp.Pages;

namespace TaskManagerApp.MVVM
{
    public class TasksListViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<TasksViewModel> TasksList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateTaskCommand { protected set; get; }
        public ICommand SaveTaskCommand { protected set; get; }
        public ICommand DeleteTaskCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        public ICommand UpdateCommand { protected set; get; }
        TasksViewModel selectedTask;
        public Users curr_user;

        public INavigation Navigation { get; set; }

        public TasksListViewModel(Users user)
        {
            TasksList = new ObservableCollection<TasksViewModel>();
            CreateTaskCommand = new Command(CreateTask);
            SaveTaskCommand = new Command(SaveTask);
            DeleteTaskCommand = new Command(DeleteTask);
            BackCommand = new Command(Back);
            UpdateCommand = new Command(Update);
            this.curr_user = user;
        }

        public TasksViewModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                if (selectedTask != value)
                {
                    TasksViewModel tempTask = value;
                    selectedTask = null;
                    OnPropertyChanged("SelectedUser");
                    Navigation.PushAsync(new TaskPage(tempTask, curr_user));
                }
            }
        }

        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void CreateTask()
        {
            Navigation.PushAsync(new TaskPage(new TasksViewModel() { ListViewModel = this }, curr_user));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private async void SaveTask(object taskObj)
        {
            TasksViewModel taskS = taskObj as TasksViewModel;
            if((taskS != null) && taskS.isValid())
            {
                bool postRes = false;
                TaskService ts = new TaskService();
                postRes = await ts.PostAsync(taskS.task);
                if (postRes)
                    TasksList.Add(taskS);

            }
            Back();
        }

        private async void DeleteTask(object taskObj)
        {
            TasksViewModel taskD = taskObj as TasksViewModel;
            if(taskD != null && taskD.isValid())
            {
                bool delRes = false;
                TaskService ts = new TaskService();
                delRes = await ts.DeleteAsync(taskD.task);
                if (delRes)
                    TasksList.Remove(taskD);
            }
            Back();
        }

        private async void Update(object taskObj)
        {
            TasksViewModel taskD = taskObj as TasksViewModel;

        }
    }
}
