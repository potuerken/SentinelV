using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
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
    }
}
