using Business.Abstract;
using Check.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NobetSistemController : ControllerBase
    {
        INobetSistemService _nobetSistemService;
        INobetListesiService _nobetListesiService;

        public NobetSistemController(INobetSistemService nobetSistemService, INobetListesiService nobetListesiService)
        {
            _nobetListesiService = nobetListesiService;
            _nobetSistemService = nobetSistemService;
        }

        [HttpGet("getsistemlist")]
        public IActionResult GetSistemList()
        {
            var nobetSistemList = _nobetSistemService.GetNobetSistemList();
            if (nobetSistemList.Success)
                return Ok(nobetSistemList.Data);
            return BadRequest(nobetSistemList.Message);
        }

        [HttpGet("getnobetlistesi")]
        public IActionResult GetNobetListesi()
        {
            var nobetListesi = _nobetListesiService.GetNobetListesi();
            if (nobetListesi.Success)
                return Ok(nobetListesi.Data);
            return BadRequest(nobetListesi.Message);
        }

        [HttpGet("getnobetlistesidetay")]
        public IActionResult GetNobetListesiDetay(int Id)
        {
            var nobetListesiDetay = _nobetListesiService.GetNobetListesiDetay(Id);
            if (nobetListesiDetay.Success)
                return Ok(nobetListesiDetay.Data);
            return BadRequest(nobetListesiDetay.Message);
        }


        [HttpPost("nobetsistemadded")]
        public IActionResult NobetSistemAdded(NobetSistemDTO dto)
        {
            var nobetSisAdd = _nobetSistemService.NobetSistemAdded(dto);
            if (nobetSisAdd.Success)
                return Ok(nobetSisAdd);
            return BadRequest(nobetSisAdd.Message);
        }



        [HttpPost("nobetlisteadded")]
        public IActionResult NobetListeAdded(NobetListesiDTO dto)
        {
            var nobetSisAdd = _nobetListesiService.NobetListeAdded(dto);
            if (nobetSisAdd.Success)
                return Ok(nobetSisAdd);
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "naughty");
            return BadRequest(nobetSisAdd.Message);
            //return new BadRequestErrorMessageResult(nobetSisAdd.Message, );
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
