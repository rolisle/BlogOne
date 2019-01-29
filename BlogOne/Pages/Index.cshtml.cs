﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogOne.Core;
using BlogOne.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BlogOne.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IBlogData _blogData;

        public IEnumerable<BlogDetails> BlogDetails { get; set; }

        public IndexModel(IConfiguration config, IBlogData blogData)
        {
            _config = config;
            _blogData = blogData;
        }
        public void OnGet()
        {
            BlogDetails = _blogData.GetAll();
        }
    }
}
