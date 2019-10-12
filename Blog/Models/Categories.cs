using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Posts> Posts { get; set; }
    }
}