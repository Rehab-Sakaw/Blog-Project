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
    public class CommentController : ApiController
    {
        private BlogContext context = new BlogContext();
        [HttpPost]
        public IHttpActionResult AddComment(CommentVM commentVM)
        {
            try
            {
                if (commentVM.UserName != null)
                {
                    var user = context.User.Where(u => u.Name == commentVM.UserName).FirstOrDefault();

                    if (commentVM.Description.Length > 1)
                    {

                        Comment newComment = new Comment()
                        {
                            Describtion = commentVM.Description,
                            CommentTime = DateTime.Now.Date,
                            PostID = commentVM.PostID,
                            UserID = user.ID
                        };
                        context.Comments.Add(newComment);
                        context.SaveChanges();
                        
                    }
                    else
                    {
                        return BadRequest("Short Comment");
                    }

                }
                string location = "http://localhost:60201/api/Comment";

                return Created(location, "Comment Saved");

            }
            catch(Exception e)
            {
                throw e;
                //return BadRequest("Not Falid Comment");

            }
        }
    }
}
