using System;
using System.Collections.Generic;
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
        BlogDetails Delete(int id);
        int Commit();
    }
}
