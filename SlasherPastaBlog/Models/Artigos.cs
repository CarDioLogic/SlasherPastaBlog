using System.ComponentModel.DataAnnotations;

namespace SlasherPastaBlog.Models
{
    public class Artigos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira um titulo para o artigo.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O artigo precisa de ter conteúdo.")]
        public string Conteudo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Role { get; set; } //To determine which user roles can access the artigo

        //relationship
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<ArtigoRatings> Ratings { get; set; }
    }
}
