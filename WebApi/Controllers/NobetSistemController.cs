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

        [HttpPost("nobetsistemadded")]
        public IActionResult NobetSistemAdded(NobetSistemDTO dto)
        {
            var nobetSisAdd = _nobetSistemService.NobetSistemAdded(dto);
            if (nobetSisAdd.Success)
                return Ok(nobetSisAdd);
            return BadRequest(nobetSisAdd.Message);
        }

        [HttpPut("nobetsistemupdated")]
        public IActionResult NobetSistemUpdated(NobetSistemDTO dto)
        {
            var nobetSisAdd = _nobetSistemService.NobetSistemUpdated(dto);
            if (nobetSisAdd.Success)
                return Ok(nobetSisAdd);
            return BadRequest(nobetSisAdd.Message);
        }


        [HttpGet("sabitNobetci")]
        public IActionResult SabitNobetci(int nobetSistemId)
        {
            var sabitPersonelList = _nobetSistemService.GetSabitNobetByNobetSistemId(nobetSistemId);
            if (sabitPersonelList.Success)
                return Ok(sabitPersonelList.Data);

            return BadRequest(sabitPersonelList.Message);
        }

        [HttpPost("nobetsistemsabitadded")]
        public IActionResult NobetSistemSabitAdded(NobetSistemSabitNobetciIliskiDTO dto)
        {
            var sabitNobAdd = _nobetSistemService.NobetSistemSabitAdded(dto);
            if (sabitNobAdd.Success)
                return Ok(sabitNobAdd);
            return BadRequest(sabitNobAdd.Message);
        }
    }
}
