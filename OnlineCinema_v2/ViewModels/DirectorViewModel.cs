using System.ComponentModel.DataAnnotations;

namespace OnlineCinema_v2.ViewModels
{
    public class DirectorViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateOnly BirthDate { get; set; }
    }
}
