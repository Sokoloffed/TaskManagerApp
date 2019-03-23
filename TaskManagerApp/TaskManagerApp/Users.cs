namespace TaskManagerApp
{
    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Tasks[] Tasks { get; set; }

        public Branches[] Branches { get; set; }
    }
}
