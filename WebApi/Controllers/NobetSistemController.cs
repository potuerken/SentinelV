using Business.Abstract;
using Check.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NobetSistemController : ControllerBase
    {
        INobetSistemService _nobetSistemService;

        public NobetSistemController(INobetSistemService nobetSistemService)
        {
            _nobetSistemService = nobetSistemService;
        }

        [HttpGet("getsistemlist")]
        public IActionResult GetSistemList()
        {
            var nobetSistemList = _nobetSistemService.GetNobetSistemList();
            //List<NobetSistemDTO> res = nobetSistemList.Data.Where(a => a.AktifMi == true && a.RutbeIliskiListesi.Where(c=>c.AktifMi == true).ToList()).ToList();

            if (nobetSistemList.Success)
                return Ok(nobetSistemList.Data);
            return BadRequest(nobetSistemList.Message);
        }
    }
}
