using CountryLibrary.Models;
using CountryLibrary.Services.Interfaces;
using Microsoft.Net.Http.Headers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace CountryLibrary.Services
{
    public class CountriesInfoService : ICountryService
    {
        private readonly IHttpClientFactory _httpClient;
        public CountriesInfoService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        #region GetCountryByArea
        public async Task<List<CountryInfo>> GetCountryByArea(string region, string timezones)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://restcountries.com/v2/region/{region}");

            var httpClient = _httpClient.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string jsonString = await TryReadAsStringAsync(httpResponseMessage);
                return GetCountryInfosRegion(jsonString,timezones);
            }

            var jsonErrorString = await TryReadAsStringAsync(httpResponseMessage);

            //Catching
            var catchExeption = GetErrorResponse(jsonErrorString);
            throw new Exception($"Error from third party:{catchExeption.Message}");
        }
        #endregion

        #region GetCountryByName
        public async Task<CountryInfo> GetCountryByName(string countryName)
        {
            var httpRequestMessage = new HttpRequestMessage(
                                            HttpMethod.Get,
                                            $"https://restcountries.com/v2/name/{countryName}");



            var httpClient = _httpClient.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string jsonString = await TryReadAsStringAsync(httpResponseMessage);
                return GetCountryInfo(jsonString);
            }

            var jsonErrorString = await TryReadAsStringAsync(httpResponseMessage);
            var catchExeption = GetErrorResponse(jsonErrorString);
            throw new Exception($"Error from third party:{catchExeption.Message}");
        }
        #endregion

        #region GetErrorResponse
        /// <summary>
        /// Catch Error Exception
        /// </summary>
        /// <param name="jsonErrorString"></param>
        /// <exception cref="Exception"></exception>
        private static CountryErrorResponse GetErrorResponse(string jsonErrorString)
        {
            var catchExeption = JsonSerializer.Deserialize<CountryErrorResponse>(jsonErrorString);
            if (catchExeption == null)
            {
                throw new Exception("Response empty from third party");
            }
            return catchExeption;
        }
        #endregion

        #region GetCountryInfoCountryByName
        private static CountryInfo GetCountryInfo(string jsonString)
        {
            var countries = JsonSerializer.Deserialize<List<Country>>(jsonString);

            //To avoid .First
            if (countries.Count == 0)
            {
                throw new Exception("Response empty from third party");
            }
            var country = countries.First();

            return new CountryInfo(country.name, country.alpha2Code, country.capital, country.CallingCode, country.flag, country.Timezone);
        }
        #endregion

        #region GetCountryInfosByArea
        private static List<CountryInfo> GetCountryInfosRegion(string jsonString, string timezones)
        {
            var countryRegions = JsonSerializer.Deserialize<List<Country>>(jsonString);
            
            //Contain filter in timezone
            var countries = countryRegions.Where(x => x.Timezone==timezones);

            var countryResponse = new List<CountryInfo>();

            foreach(var country in countries)
            {
                countryResponse.Add(new CountryInfo(country.name, country.alpha2Code, country.capital, country.CallingCode, country.flag, country.Timezone));
            }
            return countryResponse;
        }
        #endregion

        #region TryReadAsStringAsync
        private static async Task<string> TryReadAsStringAsync(HttpResponseMessage httpResponseMessage)
        {
            var jsonString =
                await httpResponseMessage.Content.ReadAsStringAsync();

            if (jsonString == null || jsonString == "")
            {
                throw new Exception("Cannot read from url");
            }

            return jsonString;
        }
        #endregion
    }
}
