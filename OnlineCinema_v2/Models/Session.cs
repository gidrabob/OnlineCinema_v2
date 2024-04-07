using System.ComponentModel.DataAnnotations;

namespace OnlineCinema_v2.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        public DateTime SessionTime { get; set; }

        public Film? Film { get; set; }
        public virtual IEnumerable<Film> Films { get; set; } = [];
    }
}
