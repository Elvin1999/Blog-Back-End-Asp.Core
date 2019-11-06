using System.Collections.Generic;
using Blog.Models;

namespace Blog.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
        public string Comment { get; set; }
    }
}