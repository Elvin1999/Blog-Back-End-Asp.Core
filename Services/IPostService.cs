using System.Collections;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Services
{
    public interface IPostService
    {
         IList<Post> GetAll();
         Post AddPost(Post post);
         Comment AddComment(string comment,int post_id);
    }
}