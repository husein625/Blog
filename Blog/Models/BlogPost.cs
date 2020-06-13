using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }


       

        [Required(ErrorMessage = "Please enter the title of the blog")]
        [Display(Name = "Title")]
        [StringLength(50)]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required(ErrorMessage = "Please enter the description of the blog")]
        [Display(Name = "Description")]
        [StringLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the body of the blog")]
        [Display(Name = "Body")]
        [StringLength(250)]
        public string Body { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated at")]
        public DateTime? UpdatedAt { get; set; }


        [Display(Name = "Tag list")]
        public int? TagListID { get; set; }
        public TagList TagList { get; set; }
    }
}
