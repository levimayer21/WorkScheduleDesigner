using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Beosztasok;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Controllers
{
    public class BeosztasController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetBeosztasok() 
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeosztasById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query() {Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBeosztas(Beosztas beosztas)
        {
            return HandleResult(await Mediator.Send(new Create.Command() { Beosztas = beosztas}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBeosztas(Beosztas beosztas, Guid id)
        {
            beosztas.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command() {Beosztas = beosztas}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeosztas(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command() {Id = id}));
        }
    }
}