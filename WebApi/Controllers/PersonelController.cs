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

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
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
        public IActionResult KodAdded(PersonelDTO dto)
        {
            var personelAdded = _personelService.PersonelAdded(dto);
            if (personelAdded.Success)
                return Ok(personelAdded);
            return BadRequest(personelAdded.Message);
        }

        [HttpPut("personelupdated")]
        public IActionResult KodUpdated(PersonelDTO dto)
        {
            var personelUpdate = _personelService.PersonelUpdated(dto);
            if (personelUpdate.Success)
                return Ok(personelUpdate);
            return BadRequest(personelUpdate.Message);
        }

        [HttpPut("personeldeleted")]
        public IActionResult KodDeleted(PersonelDTO dto)
        {
            var personelDeleted = _personelService.PersonelDeleted(dto);
            if (personelDeleted.Success)
                return Ok(personelDeleted);
            return BadRequest(personelDeleted.Message);
        }
    }
}
