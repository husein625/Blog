﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class BlogPostViewModel
    {
        public int BlogPostID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? TagListID { get; set; }
        public string TagListName { get; set; }
    }
}
