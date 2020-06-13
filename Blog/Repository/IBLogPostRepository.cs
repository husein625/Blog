using Blog.Models;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public interface IBLogPostRepository
    {
        Task<List<TagList>> GetTags();

        Task<List<BlogPostViewModel>> GetBlogPosts();

        Task<BlogPostViewModel> GetBlogPost(int? postId);

        Task<int> AddBlogPost(BlogPost post);

        Task<int> DeleteBlogPost(int? postId);

        Task UpdateBlogPost(BlogPost post);

    }
}
