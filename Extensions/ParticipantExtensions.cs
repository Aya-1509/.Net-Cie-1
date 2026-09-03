using CollegeFestMVC.Models;

namespace CollegeFestMVC.Extensions
{
    public static class ParticipantExtensions
    {
        public static string GetRegistrationStatus(this Participant participant)
        {
            if (participant.IsConfirmed.HasValue && participant.IsConfirmed.Value)
            {
                return "Confirmed";
            }
            return "Pending";
        }

        public static string GetFeeCategory(this decimal fee)
        {
            if (fee == 0) return "Free Event";
            if (fee <= 200) return "Standard Event";
            return "Premium Event";
        }

        public static decimal GetEventFee(this string eventName)
        {
            return eventName switch
            {
                "Coding Competition" => 0,
                "Web Design" => 150,
                "Robo Race" => 300,
                "Tech Quiz" => 0,
                _ => 100
            };
        }
    }
}