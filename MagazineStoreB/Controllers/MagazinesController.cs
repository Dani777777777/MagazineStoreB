using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MagazineStoreB.BL.Interfaces;
using MagazineStoreB.Models.DTO;
using MagazineStoreB.Models.Requests;

namespace MagazineStoreB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MagazinesController : ControllerBase
    {
        private readonly IMagazineService _magazineService;
        private readonly IMapper _mapper;
        private readonly ILogger<MagazinesController> _logger;

        public MagazinesController(
            IMovieService magazineService,
            IMapper mapper,
            ILogger<MagazinesController> logger)
        {
            _magazineService = magazineService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _magazineService.GetMovies();

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string id)
        {
            if (!string.IsNullOrEmpty(id)) return BadRequest();

            var result =
                _magazineService.GetMagazineById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("AddMagazine")]
        public async Task<IActionResult> AddMagazine(
            [FromBody]AddmagazineRequest MagazineRequest)
        {
            if (MagazineRequest == null) return BadRequest();

            var magazine = _mapper.Map<Magazine>(MagazineRequest);

            await _magazineService.AddMovie(magazine);

            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id)) return BadRequest($"Wrong id:{id}");

            _magazineService.DeleteMovie(id);

            return Ok();
        }
    }
}
