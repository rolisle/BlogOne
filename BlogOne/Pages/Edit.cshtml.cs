using BlogOne.Core;
using BlogOne.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogOne.Pages
{
    public class EditModel : PageModel
    {
        private readonly IBlogData _blogData;

        [BindProperty]
        public BlogDetails BlogDetails { get; set; }

        //data service
        public EditModel(IBlogData blogData)
        {
            _blogData = blogData;
        }

        //retrieving id from BlogDetails
        public IActionResult OnGet(int? blogDetailsId)
        {

            BlogDetails = blogDetailsId.HasValue ? _blogData.GetById(blogDetailsId.Value) : new BlogDetails();

            //if no id is found
            if (BlogDetails == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (BlogDetails.Id > 0)
            {
                _blogData.Update(BlogDetails);
                TempData["Message"] = "Post Updated!";
            }
            else
            {
                _blogData.Add(BlogDetails);
                TempData["Message"] = "Post Added!";
            }
            _blogData.Commit();       
            //redirects to index
            return RedirectToPage("./Index");
        }
    }
}