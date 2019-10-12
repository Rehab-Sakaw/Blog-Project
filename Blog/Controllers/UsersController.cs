using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Blog.Models;

namespace Blog.Controllers
{
   //[Authorize]
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private BlogContext Context = new BlogContext();

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            return Ok(Context.User.ToList());
        }

        // GET: api/Users/5
        public IHttpActionResult GetUserByID(int id)
        {
            User user = Context.User.FirstOrDefault(u => u.ID == id);
            if (user !=null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("User doesn't exsiste");
            }

        }

        [HttpPost]
        public IHttpActionResult AddUser(User user)
        {
            if (user.Name.Length > 2)
            {
                Context.User.Add(user);
                Context.SaveChanges();
                string location = "http://localhost:60201/api/Users/" + user.ID;

                return Created(location, "User Saved");
            }
            else
            {
                return BadRequest("User name should be 2 or more character");
            }

        }

        
        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = Context.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            Context.User.Remove(user);
            Context.SaveChanges();

            return Ok(user);
        }



        private bool UserExists(int id)
        {
            return Context.User.Count(e => e.ID == id) > 0;
        }
        
        
    }
}