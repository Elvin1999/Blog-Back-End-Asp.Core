namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int Post_Id { get; set; }
    }
}