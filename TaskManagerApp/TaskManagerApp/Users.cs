using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerApp
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public IEnumerable<Tasks> Tasks { get; set; }
        public IEnumerable<Branches> Branches { get; set; }

        public override bool Equals(object obj)
        {
            Users user = obj as Users;
            return this.id == user.id;
        }
    }
}
