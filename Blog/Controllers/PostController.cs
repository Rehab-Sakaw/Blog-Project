using Blog.Models;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog.Controllers
{
    //[Authorize]
    public class PostController : ApiController
    {
        private BlogContext Context = new BlogContext();

        // GET: api/Users
        public IHttpActionResult GetPosts()
        {
            var Posts = (from posts  in Context.Post
                        from user in Context.User
                        from cat in Context.Category
                        where posts.UserID == user.ID && posts.CategoryID == cat.ID
                        select new PostVM
                        {
                            Title = posts.Title,
                            ID = posts.ID,
                            PostTime = posts.PostTime,
                            Description = posts.Describtion,
                           CategoryName = cat.Name,
                           UserName = user.Name,
                           USerID = user.ID,
                           CategoryID = cat.ID
                        }).ToList();
            HashSet<PostVM> postsList = new HashSet<PostVM>();
            foreach (var Postitem in Posts)
            {
                var commentlistvm = (from comtbl in Context.Comments
                                     from acctbl in Context.User
                                     where comtbl.PostID == Postitem.ID && acctbl.ID == comtbl.UserID
                                     select new CommentVM()
                                     {
                                         UserName = acctbl.Name,
                                         USerID = acctbl.ID,
                                         PostID = Postitem.ID,
                                         CommentDate = comtbl.CommentTime,
                                         Description = comtbl.Describtion
                                     }).ToList();
                Postitem.Comments = commentlistvm;
                Postitem.CommentsCounter = commentlistvm.Count;
                postsList.Add(Postitem);
            }
            //PostVM postVM = new PostVM();
            return Ok(postsList);
        }
        [HttpGet]
        public IHttpActionResult GetPostsByCategoryID(int ID)
        {
            var Posts = (from posts in Context.Post
                         from user in Context.User
                         from cat in Context.Category
                         where posts.UserID == user.ID && posts.CategoryID == ID && posts.CategoryID == cat.ID
                         orderby posts.ID descending
                         select new PostVM
                         {
                             Title = posts.Title,
                             ID = posts.ID,
                             PostTime = posts.PostTime,
                             Description = posts.Describtion,
                             CategoryName = cat.Name,
                             UserName = user.Name,
                             USerID = user.ID,
                             CategoryID = ID
                         }).ToList();
            HashSet<PostVM> postsList = new HashSet<PostVM>();
            foreach (var Postitem in Posts)
            {
                var commentlistvm = (from comtbl in Context.Comments
                                     from acctbl in Context.User
                                     where comtbl.PostID == Postitem.ID && acctbl.ID == comtbl.UserID
                                     select new CommentVM()
                                     {
                                         UserName = acctbl.Name,
                                         USerID = acctbl.ID,
                                         PostID = Postitem.ID,
                                         CommentDate = comtbl.CommentTime,
                                         Description = comtbl.Describtion
                                     }).ToList();
                Postitem.Comments = commentlistvm;
                Postitem.CommentsCounter = commentlistvm.Count;
                postsList.Add(Postitem);
            }
            //PostVM postVM = new PostVM();
            return Ok(postsList);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IHttpActionResult AddPosts(PostVM PostVm)
        {
            try
            {
                if (PostVm.UserName != null)
                {
                    var user = Context.User.Where(u => u.Name == PostVm.UserName).FirstOrDefault();

                    Posts newpost = new Posts()
                    {
                        Title = PostVm.Title,
                        Describtion = PostVm.Description,
                        PostTime = DateTime.Now.Date,
                        CategoryID = PostVm.CategoryID,
                        UserID = user.ID,

                    };

                    Context.Post.Add(newpost);
                    Context.SaveChanges();
                    //Context.Database.ExecuteSqlCommand("insert into [dbo].[Posts] ([Title],[Describtion],[PostTime],[UserID],[CategoryID]) values({0},{1},{2}, {3}, {4})",newpost.Title,newpost.Describtion,newpost.PostTime,newpost.UserID,newpost.CategoryID);
                    
                }
                string location = "http://localhost:60201/api/Post";

                return Created(location, "Post Saved");
            }
            catch(Exception e)
            {
                throw e;
               // return BadRequest(e.Message);
            }
            
        }
    }
}
