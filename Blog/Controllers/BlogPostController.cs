using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repository;
using Blog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly BlogRepository _blogRepository;
        private readonly SlugParameterTransformer _slugParameterTransformer;
        public BlogPostController(BlogRepository blogRepository, SlugParameterTransformer slugParameterTransformer)
        {
            _blogRepository = blogRepository;
            _slugParameterTransformer = slugParameterTransformer;
        }

        [HttpGet]
        [Route("GetTags")]
        public async Task<IActionResult> GetTags()
        {
            try
            {
                var tags = await _blogRepository.GetTags();
                if (tags == null)
                {
                    return NotFound();
                }

                return Ok(tags);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetBlogPosts")]
        public async Task<IActionResult> GetBlogPosts()
        {
            try
            {
                var blogPosts = await _blogRepository.GetBlogPosts();
                if (blogPosts == null)
                {
                    return NotFound();
                }

                return Ok(blogPosts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetBlogPost")]
        public async Task<IActionResult> GetBlogPost(int? postId)
        {
            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await _blogRepository.GetBlogPost(postId);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddBlogPost")]
        public async Task<IActionResult> AddBlogPost([FromBody]BlogPost model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Slug = model.Title;
                    model.Slug = _slugParameterTransformer.TransformOutbound(model.Slug);
                    model.Slug.Replace(' ', '-');
                    var postId = await _blogRepository.AddBlogPost(model);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteBlogPost")]
        public async Task<IActionResult> DeleteBlogPost(int? postId)
        {
            int result = 0;

            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _blogRepository.DeleteBlogPost(postId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("UpdateBlogPost")]
        public async Task<IActionResult> UpdateBlogPost([FromBody]BlogPost model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _blogRepository.UpdateBlogPost(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }



    }






}
