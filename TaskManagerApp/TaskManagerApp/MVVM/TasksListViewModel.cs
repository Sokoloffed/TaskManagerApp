using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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
        TasksViewModel selectedTask;

        public INavigation Navigation { get; set; }

        public TasksListViewModel()
        {
            TasksList = new ObservableCollection<TasksViewModel>();
            CreateTaskCommand = new Command(CreateTask);
            SaveTaskCommand = new Command(SaveTask);
            DeleteTaskCommand = new Command(DeleteTask);
            BackCommand = new Command(Back);
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
                    Navigation.PushAsync(new TasksPage(tempTask));
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
            Navigation.PushAsync(new TasksPage(new TasksViewModel() { ListViewModel = this }));
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

            }
            Back();
        }
    }
}
