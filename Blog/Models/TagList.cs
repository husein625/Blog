using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class TagList
    {
        [Key]
        public int TagListId { get; set; }


        [Required(ErrorMessage = "Please enter the name of the tag")]
        [Display(Name = "Tag")]
        [StringLength(50)]
        public string Name { get; set; }


        public List<BlogPost> BlogPosts { get; set; }
    }
}
