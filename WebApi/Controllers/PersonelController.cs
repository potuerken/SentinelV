using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        IPersonelService _personelService;
        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpGet("getpersonel")]
        [Authorize]
        public IActionResult GetPersonel()
        {
            var personelList = _personelService.GetPersonelList();
            if (personelList.Success)
                return Ok(personelList.Data);

            return BadRequest(personelList.Message);
        }
    }
}
