using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogOne.Core;

namespace BlogOne.Data
{
    public interface IBlogData
    {
        IEnumerable<BlogDetails> GetBlogByTitle(string title);
        BlogDetails GetById(int id);
        BlogDetails Update(BlogDetails updateBlog);
        BlogDetails Add(BlogDetails newBlogPost);
        int Commit();
    }

    public class InMemoryBlogData : IBlogData
    {
        readonly List<BlogDetails> _blogDetails;

        public InMemoryBlogData()
        {
            _blogDetails = new List<BlogDetails>()
            {
                new BlogDetails { Id = 1, Title = "My first blog post", Date = "28.01.19", TextBody = "Vestibulum fermentum lorem eu elit dapibus ultrices. Morbi egestas in sem at tincidunt. Ut nec porttitor magna. Quisque eu tempor arcu. Cras laoreet nibh consectetur pharetra iaculis." },
                new BlogDetails { Id = 2, Title = "Nullam tempus", Date = "29.01.19", TextBody = "Vivamus convallis magna at augue suscipit consectetur. Ut aliquet nibh at orci ultricies lacinia." },
                new BlogDetails { Id = 3, Title = "Praesent at sapien lorem", Date = "30.01.19", TextBody = "Morbi sit amet consequat massa. Nam tincidunt leo diam, vitae semper tortor aliquam eget." }
            };
        }

        public BlogDetails GetById(int id)
        {
            return _blogDetails.SingleOrDefault(b => b.Id == id);
        }

        public BlogDetails Add(BlogDetails newBlogPost)
        {
            _blogDetails.Add(newBlogPost);
            newBlogPost.Id = _blogDetails.Max(b => b.Id) + 1;
            return newBlogPost;
        }

        public BlogDetails Update(BlogDetails updateBlog)
        {
            var blogDetails = _blogDetails.SingleOrDefault(b => b.Id == updateBlog.Id);
            if (blogDetails != null)
            {
                blogDetails.Title = updateBlog.Title;
                blogDetails.Date = updateBlog.Date;
                blogDetails.TextBody = updateBlog.TextBody;
            }
            return blogDetails;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<BlogDetails> GetBlogByTitle(string title)
        {
            return from b in _blogDetails
                where string.IsNullOrEmpty(title) || b.Title.StartsWith(title)
                orderby b.Title
                select b;
        }
    }
}
