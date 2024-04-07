using System.ComponentModel.DataAnnotations;

namespace OnlineCinema_v2.Models
{
    public class FilmGenre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<Film> Films { get; set; } = [];
    }
}
