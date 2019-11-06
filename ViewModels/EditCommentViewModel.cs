using Blog.Models;

namespace Blog.ViewModels
{
    public class EditCommentViewModel
    {
        public Comment Comment { get; set; }
        public int Post_Id { get; set; }
    }
}