namespace ApiTestsPOC.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Post_Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Body { get; set; } = "";
    }
}
