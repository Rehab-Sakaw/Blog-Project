using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class CommentVM
    {
        public int USerID { get; set; }
        public string UserName { get; set; }
        public int PostID { get; set; }
        public string Description { get; set; }
        public DateTime CommentDate { get; set; }
    }
}