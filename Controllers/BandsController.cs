using BandAPI.Services;
using BandAPI.Models;
using BandAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandAPI.Helpers;
using AutoMapper;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/bands")]
    public class BandsController : ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public BandsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ?? throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        //This is the original GetBands controller method prior to implementing BandDto or IMapper
        [HttpGet("/GetBands1")]
        public IActionResult GetBands1()
        {
            var bandsFromRepo = _bandAlbumRepository.GetBands();
            return Ok(bandsFromRepo);
        }

        [HttpGet("/GetBandsDtoModel")]
        public ActionResult<IEnumerable<BandDto>> GetBandsDtoModel()
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

        [HttpGet("/GetBandsIMapper")]
        public ActionResult<IEnumerable<BandDto>> GetBandsIMapper()
        {
            var bandsFromRepo = _bandAlbumRepository.GetBands();
            var bandsDto = new List<BandDto>();

            //foreach (var band in bandsFromRepo)
            //{
            //    bandsDto.Add(new BandDto()
            //    {
            //        Id = band.Id,
            //        Name = band.Name,
            //        MainGenre = band.MainGenre,
            //        FoundedYearsAgo = $"{band.Founded.ToString("yyyy")} ({band.Founded.GetYearsAgo()} years ago)"
            //    });
            //}

            return Ok(_mapper.Map<IEnumerable<BandDto>>(bandsFromRepo));

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
