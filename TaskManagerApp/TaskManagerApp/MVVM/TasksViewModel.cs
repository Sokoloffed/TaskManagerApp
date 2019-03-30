using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TaskManagerApp.MVVM
{
    public class TasksViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        TasksListViewModel tlvm;
        public Tasks task { get; set; }

        public TasksViewModel()
        {
            task = new Tasks();
        }

        public TasksListViewModel ListViewModel
        {
            get { return tlvm; }
            set
            {
                if (tlvm != value)
                {
                    tlvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public bool isValid()
        {
            return true;
        }

        public int id
        {
            get { return task.id; }
            set
            {
                if(task.id != value)
                {
                    task.id = value;
                    OnPropertyChanged("id");
                }
            }
        }

        public string taskname
        {
            get { return task.taskname; }
            set
            {
                if (task.taskname != value)
                {
                    task.taskname = value;
                    OnPropertyChanged("taskname");
                }
            }

        }

        public string description
        {
            get { return task.description; }
            set
            {
                if (task.description != value)
                {
                    task.description = value;
                    OnPropertyChanged("description");
                }
            }

        }

        public DateTime date_begin
        {
            get { return task.date_begin; }
            set
            {
                if (task.date_begin != value)
                {
                    task.date_begin = value;
                    OnPropertyChanged("date_begin");
                }
            }
        }

        public DateTime? date_end
        {
            get { return task.date_end; }
            set
            {
                if (task.date_end != value)
                {
                    task.date_end = value;
                    OnPropertyChanged("date_end");
                }
            }
        }

        public string status
        {
            get { return task.status; }
            set
            {
                if (task.status != value)
                {
                    task.status = value;
                    OnPropertyChanged("status");
                }
            }
        }

        public int creator_id
        {
            get { return task.creator_id; }
            set
            {
                if (task.creator_id != value)
                {
                    task.creator_id = value;
                    OnPropertyChanged("creator_id");
                }
            }
        }

        public int? executor_id
        {
            get { return task.executor_id; }
            set
            {
                if (task.executor_id != value)
                {
                    task.executor_id = value;
                    OnPropertyChanged("executor_id");
                }
            }

        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
