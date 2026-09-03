using System.ComponentModel.DataAnnotations;

namespace CollegeFestMVC.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }

        [Required(ErrorMessage = "Participant name is required.")]
        public string ParticipantName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required.")]
        public string Year { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event selection is required.")]
        public string EventName { get; set; } = string.Empty;

        public bool IsTeamEvent { get; set; }

        public bool? IsConfirmed { get; set; } = true; 
    }
}