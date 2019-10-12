using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class PostVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostTime { get; set; }
        public int CommentsCounter { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int USerID { get; set; }
        public string UserName { get; set; }
        //public Categories Category { get; set; } = new Categories();
        //public User Account { get; set; } = new User();
        public List<CommentVM> Comments { get; set; } = new List<CommentVM>();
    }
}