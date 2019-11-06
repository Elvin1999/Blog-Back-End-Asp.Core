using System.Collections;
using System.Collections.Generic;
using Blog.Models;
using System.Linq;

namespace Blog.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts;
        public PostService()
        {
            _posts = new List<Post>(){
                new Post(){
                    Id=1,
                    Title="Title 1",
                     Content="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                     Comments=new List<Comment>(){
                         new Comment(){
                             Id=1,
                             Content="Lorem Ipsum is simply dummy text of the printing"
                         },
                           new Comment(){
                               Id=2,
                             Content="Lorem Ipsum is simply dummy text of the printing"
                         },
                           new Comment(){
                               Id=3,
                             Content="Lorem Ipsum is simply dummy text of the printing"
                         },
                     }
                },
                   new Post(){
                       Id=2,
                    Title="Title 2",
                     Content="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                     Comments=new List<Comment>(){
                          new Comment(){
                            Id=4,
                             Content="Lorem Ipsum is simply dummy text of the printing"
                         },
                           new Comment(){
                               Id=5,
                             Content="Lorem Ipsum is simply dummy text of the printing"
                         },
                           new Comment(){
                               Id=6,
                             Content="Lorem Ipsum is simply dummy text of the printing"
                         },
                     }
                },
                   new Post(){
                       Id=3,
                    Title="Title 3",
                     Content="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                     Comments=new List<Comment>(){
                          new Comment(){
                              Id=7,
                             Content="Lorem Ipsum is simply dummy text of the printing"
                         },
                           new Comment(){
                               Id=8,
                             Content="Lorem Ipsum is simply dummy text of the printing"
                         },
                           new Comment(){
                               Id=9,
                             Content="Lorem Ipsum is simply dummy text of the printing"
                         },
                     }
                }
            };
        }

        public Comment AddComment(string comment, int post_id)
        {
          
            var post=_posts.SingleOrDefault(x=>x.Id==post_id);
            var c=new Comment(){
                Id=post.Comments.Count+1,
                 Content=comment,
                  Post_Id=post_id
            };
            post.Comments.Add(c);
           return c;
        }

        public Post AddPost(Post post)
        {
            _posts.Add(post);
            return post;
        }

        public IList<Post> GetAll()
        {
            return _posts;
        }
 
    }
}