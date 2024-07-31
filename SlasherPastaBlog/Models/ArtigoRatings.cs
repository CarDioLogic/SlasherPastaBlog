using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SlasherPastaBlog.Models
{
    public class ArtigoRatings
    {
        public int Id { get; set; }
        public string RaterId { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }

        //relationship
        public int ArtigoId { get; set; }
        [ForeignKey("ArtigoId")]
        public Artigos Artigo { get; set; }
    }
}
