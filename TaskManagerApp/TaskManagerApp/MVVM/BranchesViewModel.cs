using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TaskManagerApp.MVVM
{
    public class BranchesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        BranchesListViewModel blvm;
        public Branches branch { get; set; }

        public BranchesViewModel()
        {
            branch = new Branches();
        }

        public BranchesListViewModel ListViewModel
        {
            get { return blvm; }
            set
            {
                if (blvm != value)
                {
                    blvm = value;
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
            get { return branch.id; }
            set
            {
                if (branch.id != value)
                {
                    branch.id = value;
                    OnPropertyChanged("id");
                }
            }
        }

        public string branchname
        {
            get { return branch.branchname; }
            set
            {
                if (branch.branchname != value)
                {
                    branch.branchname = value;
                    OnPropertyChanged("branchname");
                }
            }
        }

        public string description
        {
            get { return branch.description; }
            set
            {
                if (branch.description != value)
                {
                    branch.description = value;
                    OnPropertyChanged("description");
                }
            }
        }

        public int creator_id
        {
            get { return branch.creator_id; }
            set
            {
                if (branch.creator_id != value)
                {
                    branch.creator_id = value;
                    OnPropertyChanged("creator_id");
                }
            }
        }

        public DateTime created_date
        {
            get { return branch.created_date; }
            set
            {
                if (branch.created_date != value)
                {
                    branch.created_date = value;
                    OnPropertyChanged("created_date");
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
