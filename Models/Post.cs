using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberPost.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}