using System.ComponentModel.DataAnnotations;

namespace OnlineCinema_v2.Models
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateOnly BirthDate { get; set; }

        public virtual IEnumerable<Film> Films { get; set; } = [];
    }
}
