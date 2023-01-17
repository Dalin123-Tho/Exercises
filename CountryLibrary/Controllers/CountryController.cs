using CountryLibrary.Models;
using CountryLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;
        public CountryController(ICountryService service)
        {
            _service = service;
        }

        [HttpPost("GetCountryByName")]
        public Task<CountryInfo> GetCountryByName(string countryName)
        {
            return _service.GetCountryByName(countryName);
        }

        [HttpPost("GetCountryByArea")]
        public Task<List<CountryInfo>> GetCountryByArea(string region, string timezones)
        {
            return _service.GetCountryByArea(region, timezones);
        }
    }
}
