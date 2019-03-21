using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerApp
{
    public class Tasks
    {
        public int id { get; set; }
        public string taskname { get; set; }
        public string description { get; set; }
        public DateTime date_begin { get; set; }
        public DateTime? date_end { get; set; }
        public string status { get; set; }
        public int creator_id { get; set; }
        public int? executor_id { get; set; }

        public IEnumerable<Users> Users { get; set; }
        public IEnumerable<Branches> Branches { get; set; }
    }
}
