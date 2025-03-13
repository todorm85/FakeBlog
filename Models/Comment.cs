using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberPost.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string AuthorName { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string AuthorEmail { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
