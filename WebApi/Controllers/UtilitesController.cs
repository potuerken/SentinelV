using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Check.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]

    public class UtilitesController : ControllerBase
    {
        IUtilitesService _utilitesService;
        public UtilitesController(IUtilitesService utilitesService)
        {
            _utilitesService = utilitesService;
        }


        [HttpGet("getallkod")]
        public IActionResult GetAllKod(short kodTipId)
        {
            var kodList = _utilitesService.GetKodList(kodTipId);
            if (kodList.Success)
            {
                return Ok(kodList.Data);
            }
            return BadRequest(kodList.Message);
        }

        [HttpPost("kodadded")]
        public IActionResult KodAdded(KodDTO dto)
        {
            var kodAdded = _utilitesService.KodAdded(dto);
            if (kodAdded.Success)
                return Ok(kodAdded);
            return BadRequest(kodAdded.Message);
        }

        [HttpPut("kodupdated")]
        public IActionResult KodUpdated(KodDTO dto)
        {
            var kodAdded = _utilitesService.KodUpdated(dto);
            if (kodAdded.Success)
                return Ok(kodAdded);
            return BadRequest(kodAdded.Message);
        }

        [HttpPut("koddeleted")]
        public IActionResult KodDeleted(KodDTO dto)
        {
            var kodDeleted = _utilitesService.KodDeleted(dto);
            if (kodDeleted.Success)
                return Ok(kodDeleted);
            return BadRequest(kodDeleted.Message);
        }
    }
}
