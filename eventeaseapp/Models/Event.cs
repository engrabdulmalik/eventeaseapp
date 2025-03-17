namespace eventeaseapp.Models
{
    public class Event
    {
        public required string Name { get; set; }
        public DateTime Date { get; set; }
        public required string Location { get; set; }
    }
}