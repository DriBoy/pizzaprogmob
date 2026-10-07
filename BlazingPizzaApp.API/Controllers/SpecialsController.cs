using BlazingPizzaApp.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizzaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialsController : ControllerBase
    {
        private readonly IPizzaSpecials _pizzaSpecials;

        public SpecialsController(IPizzaSpecials pizzaSpecials)
        {
            _pizzaSpecials = pizzaSpecials;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var specials = await _pizzaSpecials.GetPizzaSpecialsAsync();
            return Ok(specials);
        }
    }
}
