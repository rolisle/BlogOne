using System.ComponentModel.DataAnnotations;

namespace BlogOne.Core
{
    public class BlogDetails
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Title { get; set; }

        [Required]
        public string TextBody { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
