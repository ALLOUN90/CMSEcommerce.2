using System.ComponentModel.DataAnnotations;

namespace CMSEcommerce.Models
{
    public class Page
    {
        public int Id { get; set; }
        [Required, MinLength(3 , ErrorMessage ="Minimum lenght is 3")]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(10, ErrorMessage = "Minimum lenght is 10")]
        public string Body { get; set; }
    }
}
