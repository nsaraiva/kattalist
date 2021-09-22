using AutoMapper;
using Kattalist.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kattalist.API.Controllers
{
    public class ListaComprasController : Controller
    {
        private readonly IMapper _mapper;

        public ListaComprasController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Route("api/[controller]")]

        // POST: ListaComprasController/Create
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<ListaCompras> Create([FromBody] ListaComprasDTO nomeLista)
        {
            if(nomeLista.Name.Length < 1 || nomeLista.Name.Contains(' ') || nomeLista == null)
            {
                return BadRequest("Name must be a string, with length bigger than 1 and no space character...");
            }

            ListaCompras _nomeLista = new ListaCompras
            {
                Name = nomeLista.Name
            };

            return Created("", _mapper.Map<ListaCompras>(_nomeLista));
        }
    }
}

