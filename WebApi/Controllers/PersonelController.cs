using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Check.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class PersonelController : ControllerBase
    {
        IPersonelService _personelService;
        IIzinMazeretService _izinMazeretService;

        public PersonelController(IPersonelService personelService, IIzinMazeretService izinMazeretService)
        {
            _personelService = personelService;
            _izinMazeretService = izinMazeretService;
        }

        [HttpGet("getpersonel")]
        public IActionResult GetPersonel()
        {
            var personelList = _personelService.GetPersonelList();
            if (personelList.Success)
                return Ok(personelList.Data);

            return BadRequest(personelList.Message);
        }


        [HttpPost("personeladded")]
        public IActionResult PersonelAdded(PersonelDTO dto)
        {
            var personelAdded = _personelService.PersonelAdded(dto);
            if (personelAdded.Success)
                return Ok(personelAdded);
            return BadRequest(personelAdded.Message);
        }

        [HttpPut("personelupdated")]
        public IActionResult PersonelUpdated(PersonelDTO dto)
        {
            var personelUpdate = _personelService.PersonelUpdated(dto);
            if (personelUpdate.Success)
                return Ok(personelUpdate);
            return BadRequest(personelUpdate.Message);
        }


        [HttpGet("iziListesi")]
        public IActionResult IzinListesi()
        {
            var izinListesi = _izinMazeretService.GetIzinList();
            if (izinListesi.Success)
                return Ok(izinListesi.Data);

            return BadRequest(izinListesi.Message);
        }

        [HttpPost("izinAdded")]
        public IActionResult IzinAdded(IzinMazeretDTO dto)
        {
            var izinListesi = _izinMazeretService.IzinAdded(dto);
            if (izinListesi.Success)
                return Ok(izinListesi);

            return BadRequest(izinListesi.Message);
        }
    }
}
