using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Data;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly CountryRepository _countryRepository;
        public CountryController(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        //this country controller use for call method from country repository
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _countryRepository.SelectAllCountries();
            return Ok(countries);
        }
    }
}
