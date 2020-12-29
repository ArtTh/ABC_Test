using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Cities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class CityController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<CityDTO>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDTO>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
    }
}