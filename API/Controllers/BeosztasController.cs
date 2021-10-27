using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Beosztasok;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BeosztasController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetBeosztasok() 
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        } 

        [HttpPost]
        public async Task<IActionResult> CreateBeosztas(Beosztas beosztas)
        {
            return HandleResult(await Mediator.Send(new Create.Command() { Beosztas = beosztas}));
        }
    }
}