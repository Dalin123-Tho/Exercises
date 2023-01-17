using System.Text.Json.Serialization;

namespace CountryLibrary.Models
{
    public class CountryInfo
    {
        public CountryInfo(string name, string alpha2Code, string capital, int callingCodes, string flagUrl, string timezones)
        {
            Name = name;
            Alpha2Code = alpha2Code;
            Capital = capital;
            CallingCodes = callingCodes;
            FlagUrl = flagUrl;
            Timezones = timezones;
        }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Alpha2Code")]
        public string  Alpha2Code { get; set; }
        [JsonPropertyName("Capital")]
        public string Capital { get; set; }
        [JsonPropertyName("CallingCodes")]
        public int CallingCodes { get; set; }
        [JsonPropertyName("FlagUrl")]
        public string FlagUrl { get; set; }
        [JsonPropertyName("Timezones")]
        public string Timezones { get; set; }
    }
}
