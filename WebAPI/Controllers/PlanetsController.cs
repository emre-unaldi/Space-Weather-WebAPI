using Business.Abstracts;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        IPlanetService _planetService;

        public PlanetsController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpPost("add")]
        public IActionResult Add(PlanetDTO planetDTO)
        {
            var result = _planetService.Add(planetDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _planetService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public IActionResult Update(PlanetDTO planetDTO)
        {
            var result = _planetService.Update(planetDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _planetService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _planetService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("pagination")]
        public IActionResult Pagination([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var result = _planetService.Pagination(pageNumber, pageSize);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("filterByTemperature")]
        public IActionResult Filter([FromQuery] int temperature)
        {
            var result = _planetService.FilterByTemperature(temperature);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("sortByNameAsc")]
        public IActionResult SortByNameAsc()
        {
            var result = _planetService.SortByNameAsc();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("sortByNameDesc")]
        public IActionResult SortByNameDesc()
        {
            var result = _planetService.SortByNameDesc();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
