using System.Text.Json.Serialization;

namespace CountryLibrary.Models
{
    public class TeamMember
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Gender")]
        public string Gender { get; set; } = string.Empty;
        [JsonPropertyName("Age")]
        public int Age { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; } = string.Empty;
        [JsonPropertyName("Email")]
        public string Email { get; set; } = string.Empty; 

    }
    
}
