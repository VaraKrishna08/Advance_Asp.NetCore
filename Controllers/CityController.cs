using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SampleApi.Controllers;
using SampleApi.Data;
using SampleApi.Models;
using System.Data;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityRepository _cityRepository;
        public CityController(CityRepository cityRepository) {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public IActionResult GetAllCities() {
            var cities = _cityRepository.SelectAll();
            return Ok(cities);
        }
    }
}