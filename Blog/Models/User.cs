using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual ICollection<Posts> Posts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}