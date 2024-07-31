using System.ComponentModel.DataAnnotations;

namespace SlasherPastaBlog.Models
{
    public class ArtigoRatingViewModel
    {
        public int ArtigoId { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
    }
}
