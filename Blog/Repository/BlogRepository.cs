using Blog.Models;
using Blog.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class BlogRepository : IBLogPostRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public BlogRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> AddBlogPost(BlogPost post)
        {
            if (_applicationDbContext != null)
            {
                await _applicationDbContext.BlogPost.AddAsync(post);
                await _applicationDbContext.SaveChangesAsync();

                return post.BlogPostId;
            }

            return 0;
        }

        public async Task<int> DeleteBlogPost(int? postId)
        {
            int result = 0;

            if (_applicationDbContext != null)
            {
                //Find the post for specific post id
                var post = await _applicationDbContext.BlogPost.FirstOrDefaultAsync(x => x.BlogPostId == postId);

                if (post != null)
                {
                    //Delete that post
                    _applicationDbContext.BlogPost.Remove(post);

                    //Commit the transaction
                    result = await _applicationDbContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<BlogPostViewModel> GetBlogPost(int? postId)
        {
            if (_applicationDbContext != null)
            {
                return await(from p in _applicationDbContext.BlogPost
                             from c in _applicationDbContext.TagList
                             where p.BlogPostId == postId
                             select new BlogPostViewModel
                             {
                                 BlogPostID = p.BlogPostId,
                                 Title = p.Title,
                                 Description = p.Description,
                                 Body = p.Body,
                                 TagListID = p.TagListID,
                                 TagListName = c.Name,
                                 CreatedAt = p.CreatedAt,
                                 UpdatedAt = p.UpdatedAt
                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<BlogPostViewModel>> GetBlogPosts()
        {
            if (_applicationDbContext != null)
            {
                return await(from p in _applicationDbContext.BlogPost
                             from c in _applicationDbContext.TagList
                             where p.TagListID == c.TagListId
                             select new BlogPostViewModel
                             {
                                 BlogPostID = p.BlogPostId,
                                 Title = p.Title,
                                 Description = p.Description,
                                 Body = p.Body,
                                 TagListID = p.TagListID,
                                 TagListName = c.Name,
                                 CreatedAt = p.CreatedAt,
                                 UpdatedAt = p.UpdatedAt
                             }).ToListAsync();
            }

            return null;
        }

        public async Task<List<TagList>> GetTags()
        {
            if (_applicationDbContext != null)
            {
                return await _applicationDbContext.TagList.ToListAsync();
            }

            return null;
        }

        public async Task UpdateBlogPost(BlogPost post)
        {
            if (_applicationDbContext != null)
            {
                //Delete that post
                _applicationDbContext.BlogPost.Update(post);

                //Commit the transaction
                await _applicationDbContext.SaveChangesAsync();
            }
        }





        private void SearchByTag(ref IQueryable<BlogPostViewModel> tags, string tagName)
        {
            if (!tags.Any() || string.IsNullOrWhiteSpace(tagName))
                return;

            tags = tags.Where(o => o.TagListName.ToLower().Contains(tagName.Trim().ToLower()));
        }

    }
}
