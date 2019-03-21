using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerApp
{
    public class Branches
    {
        public int id { get; set; }
        public string branchname { get; set; }
        public string description { get; set; }
        public int creator_id { get; set; }
        public DateTime created_date { get; set; }

        public IEnumerable<Users> Users { get; set; }
        public IEnumerable<Tasks> Tasks { get; set; }
    }
}
