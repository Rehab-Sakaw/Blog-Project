using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog.Controllers
{
    //[Authorize]
    public class CategoryController : ApiController
    {
        private BlogContext context = new BlogContext();
        public IHttpActionResult GetCategories()
        {
            return Ok(context.Category.ToList());
        }
        [HttpPost]
        public IHttpActionResult CreateCategories(Categories categories)
        {
            try
            {
                if (categories.Name.Length > 3)
                {


                    Categories Newcategories = new Categories()
                    {
                        Name = categories.Name,

                    };

                    context.Category.Add(Newcategories);
                    context.SaveChanges();
                    string location = "http://localhost:60201/api/Category";

                    return Created(location, "Category Saved");
                }
                else
                {
                    return BadRequest("Short category name");
                }

            }
            catch 
            {

                return BadRequest("Not Falid Category");
            }
            
        }
    }

}
