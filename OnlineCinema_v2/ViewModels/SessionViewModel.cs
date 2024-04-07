using System.ComponentModel.DataAnnotations;

namespace OnlineCinema_v2.ViewModels
{
    public class SessionViewModel
    {
        [Required]
        public DateTime SessionTime { get; set; }
    }
}
