using System.ComponentModel.DataAnnotations;

namespace OnlineCinema_v2.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int DirectorId { get; set; }

        [Required]
        public int FilmGenreId { get; set; }

        [Required]
        public int SessionId { get; set; }

        public virtual Director? Director { get; set; }
        public virtual IEnumerable<FilmGenre> FilmGenres { get; set; } = [];
        public virtual IEnumerable<Session> Sessions { get; set; } = [];
    }
}
