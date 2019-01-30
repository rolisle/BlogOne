using System.Collections.Generic;
using System.Linq;
using BlogOne.Core;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace BlogOne.Data
{
    public class SqlBlogOneData : IBlogData
    {
        private readonly BlogOneDbContext _db;

        public SqlBlogOneData(BlogOneDbContext db)
        {
            _db = db;
        }

        public IEnumerable<BlogDetails> GetBlogByTitle(string title)
        {
            var query = from b in _db.BlogDetails
                where b.Title.StartsWith(title) || string.IsNullOrEmpty(title)
                orderby b.Title
                select b;
            return query;
        }

        public BlogDetails GetById(int id)
        {
            return _db.BlogDetails.Find(id);
        }

        public BlogDetails Update(BlogDetails updateBlog)
        {
            // track/manage changes
            var entity = _db.BlogDetails.Attach(updateBlog);
            entity.State = EntityState.Modified;
            return updateBlog;
        }

        public BlogDetails Add(BlogDetails newBlogPost)
        {
            _db.Add(newBlogPost);
            return newBlogPost;
        }

        public BlogDetails Delete(int id)
        {
            var blogDetails = GetById(id);
            if (blogDetails != null)
            {
                _db.BlogDetails.Remove(blogDetails);
            }

            return blogDetails;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}