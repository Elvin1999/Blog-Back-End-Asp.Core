using Blog.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Blog.ViewModels;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController:Controller
    {
        private readonly IPostService _postService;
        public HomeController(IPostService _postService)
        {
            this._postService=_postService;
        }
        public IActionResult Index(){
            return new RedirectToActionResult("All","Home",null);
        }
         [HttpGet]
        public IActionResult All()
        {
            var posts = _postService.GetAll();
            var vm = posts.Select(x => new PostViewModel
            {
                Id=x.Id,
                Title = x.Title,
                Content=x.Content,
                Comments=x.Comments
            }).ToList();
            return View(vm);
        }
        
        [HttpPost]
        public IActionResult AddComment(int postId,string comment){
            _postService.AddComment(comment,postId);
            return ShowPost(postId);
        }
        [HttpPost]
        public IActionResult Edit(int postid,int commentid,string content){
                var post=_postService.GetAll().SingleOrDefault(x=>x.Id==postid);
                var comment=post.Comments.SingleOrDefault(c=>c.Id==commentid);
                comment.Content=content;
                return ShowPost(postid);
        }

        public IActionResult EditComment(int id,int id2){
            var posts = _postService.GetAll();
            var post=posts.SingleOrDefault(x=>x.Id==id);
            var comment=post.Comments.SingleOrDefault(c=>c.Id==id2);
            EditCommentViewModel evm=new EditCommentViewModel();
           evm.Post_Id=id;
            if(comment!=null){
            evm.Comment=comment;
                    } 
                    else{
                         evm.Comment=new Comment();
                    }       

            return View("editcomment",evm);
        }
        public IActionResult DeleteComment(int id,int id2){
                var posts=_postService.GetAll().SingleOrDefault(x=>x.Id==id);
                var comment=posts.Comments.SingleOrDefault(c=>c.Id==id2);
                posts.Comments.Remove(comment);
                return ShowPost(id);
        }

        public IActionResult ShowPost(int id){
            var posts = _postService.GetAll();
            var vm = posts.Select(x => new PostViewModel
            {
                Id=x.Id,
                Title = x.Title,
                Content=x.Content,
                Comments=x.Comments
            }).ToList();
            var post=vm.SingleOrDefault(x=>x.Id==id);
            return View("post",post);  
        }
    }
}