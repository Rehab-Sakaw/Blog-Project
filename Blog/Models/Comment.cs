using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        //[StringLength(500)]
        public string Describtion { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserID { get; set; }

        [ForeignKey("Post")]
        public int PostID { get; set; }

        public DateTime CommentTime { get; set; }

        // [JsonIgnore]
        public virtual User User { get; set; }

        //[JsonIgnore]
        public virtual Posts Post { get; set; }
    }
}