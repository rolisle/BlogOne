using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogOne.Core;
using BlogOne.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogOne.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IBlogData _blogData;

        public BlogDetails BlogDetails { get; set; }

        public DeleteModel(IBlogData _blogData)
        {
            this._blogData = _blogData;
        }

        public IActionResult OnGet(int blogDetailsId)
        {
            BlogDetails = _blogData.GetById(blogDetailsId);
            if (BlogDetails == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int blogDetailsId)
        {
            var blogData = _blogData.Delete(blogDetailsId);
            _blogData.Commit();

            if (blogData == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{blogData.Title} deleted";
            return RedirectToPage("./Index");
        }
    }
}