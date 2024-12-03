using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Data;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateRepository _stateRepository;
        public StateController(StateRepository stateRepository)
        {
            _stateRepository=stateRepository;
        }
        [HttpGet]
        public IActionResult GetAllState()
        {
            var states=_stateRepository.SelectAllStates();
            return Ok(states);
        }


    }
}
