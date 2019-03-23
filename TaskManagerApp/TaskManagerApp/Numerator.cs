namespace TaskManagerApp
{
    public class Numerator
    {
        public int WeekDay { get; set; }
        public int timeId { get; set; }
        public int duration { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public int optional { get; set; }
        public string teachers { get; set; }
        public string room { get; set; }
        public string build { get; set; }
        public string dates { get; set; }
    }

    public class Denominator
    {
        public int weekDay { get; set; }
        public int timeId { get; set; }
        public int duration { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public int optional { get; set; }
        public string teachers { get; set; }
        public string room { get; set; }
        public string build { get; set; }
        public string Dates { get; set; }
    }

    public class ResponceDto
    {
        public Numerator[] numerator { get; set; }
        public Denominator[] denominator { get; set; }
    }
}
