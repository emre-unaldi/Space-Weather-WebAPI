using Business.Abstracts;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SatellitesController : ControllerBase
    {
        ISatelliteService _satelliteService;

        public SatellitesController(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }

        [HttpPost("add")]
        public IActionResult Add(Satellite satellite)
        {
            var result = _satelliteService.Add(satellite);
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
            var result = _satelliteService.Delete(id);
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
        public IActionResult Update(Satellite satellite)
        {
            var result = _satelliteService.Update(satellite);
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
            var result = _satelliteService.GetAll();
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
            var result = _satelliteService.GetById(id);
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
            var result = _satelliteService.Pagination(pageNumber, pageSize);
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
            var result = _satelliteService.FilterByTemperature(temperature);
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
            var result = _satelliteService.SortByNameAsc();
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
            var result = _satelliteService.SortByNameDesc();
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
