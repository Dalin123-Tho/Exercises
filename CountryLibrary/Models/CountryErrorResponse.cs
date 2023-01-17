using System.Text.Json.Serialization;

namespace CountryLibrary.Models
{
   
    public class CountryErrorResponse
    {
        public CountryErrorResponse(string message)
        {
            Message = message;
        }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
