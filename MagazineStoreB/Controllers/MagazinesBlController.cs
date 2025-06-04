using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MagazineStoreB.BL.Interfaces;
using MagazineStoreB.Models.DTO;
using MagazineStoreB.Models.Requests;

namespace MagazineStoreB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MagazinesBlController : ControllerBase
    {
        private readonly IBlMagazineService _magazineService;
        private readonly ILogger<MoviesController> _logger;

        public MagazinesBlController(
            IBlMagazineService magazineService,
            ILogger<MagazinesController> logger)
        {
            _magazineService = magazineService;
            _logger = logger;
        }

       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =  await _magazineService.GetAllMovieDetails();

            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
    }

    public class TestRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
