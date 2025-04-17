namespace ApiTestsPOC.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Title { get; set; } = "";
        public string Due_On { get; set; } = "";
        public string Status { get; set; } = "";
    }
}
