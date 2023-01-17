using CountryLibrary.Models;

namespace CountryLibrary.Services.Interfaces
{
    public interface ICountryService
    {        
        /// <summary>
        /// To GetCountryByName
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Task<CountryInfo> GetCountryByName(string countryName);
        Task<List<CountryInfo>> GetCountryByArea(string region, string timezones);
    }
}
