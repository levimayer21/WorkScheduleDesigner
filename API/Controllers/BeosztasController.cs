using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BeosztasController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetBeosztasok() 
        {
            return Ok();
            // HandleResult(await Mediator.Send())
        } 
    }
}