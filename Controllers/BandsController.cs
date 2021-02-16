using BandAPI.Services;
using BandAPI.Models;
using BandAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandAPI.Helpers;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/bands")]
    public class BandsController : ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;

        public BandsController(IBandAlbumRepository bandAlbumRepository)
        {
            _bandAlbumRepository = bandAlbumRepository ?? throw new ArgumentNullException(nameof(bandAlbumRepository));
        }

        [HttpGet]
        public IActionResult GetBands()
        {
            var bandsFromRepo = _bandAlbumRepository.GetBands();
            return Ok(bandsFromRepo);
        }

        [HttpGet("/bandsModel")]

        //public IActionResult GetBandBands()

        //The above line can be replaced with the line below which is the base class of IActionResult
        //because List is the default return type for the base class
        public ActionResult<IEnumerable<BandDto>> GetBandBands()
        {
            var bandsFromRepo = _bandAlbumRepository.GetBands();
            var bandsDto = new List<BandDto>();

            foreach (var band in bandsFromRepo)
            {
                bandsDto.Add(new BandDto()
                {
                    Id = band.Id,
                    Name = band.Name,
                    MainGenre = band.MainGenre,
                    FoundedYearsAgo = $"{band.Founded.ToString("yyyy")} ({band.Founded.GetYearsAgo()} years ago)"
                });
            }

            return Ok(bandsDto);

        }

        [HttpGet("{bandId}")]
        public IActionResult GetBand(Guid bandId)
        {
            var bandsFromRepo = _bandAlbumRepository.GetBand(bandId);

            if (bandsFromRepo == null)
                return NotFound();

            return Ok(bandsFromRepo);
        }
    }
}
