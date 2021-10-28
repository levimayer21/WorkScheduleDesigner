using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Csoportok;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CsoportController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCsoportok()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCsoportById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query() {Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCsoport(Csoport csoport)
        {
            return HandleResult(await Mediator.Send(new Create.Command() {Csoport = csoport}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCsoport(Csoport csoport, Guid id)
        {
            csoport.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command() {Csoport = csoport}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCsoport(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command() {Id = id}));
        }
    }
}