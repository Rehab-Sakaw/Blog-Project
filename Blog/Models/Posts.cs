using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Posts
    {
        [Key]
        public int ID { get; set; }
        [Required]
        //[StringLength(50)]
        public string Title { get; set; }
        [Required]
        //[StringLength(1000)]
        public string Describtion { get; set; }
        public DateTime PostTime { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Categories")]
        public int CategoryID { get; set; }
        public virtual Categories Categories { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }

    }
}