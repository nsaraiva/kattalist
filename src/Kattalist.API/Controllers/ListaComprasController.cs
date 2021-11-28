using AutoMapper;
using FluentValidation.Results;
using Kattalist.Domain.DTOs;
using Kattalist.Domain.Entities;
using Kattalist.Domain.Interfaces;
using Kattalist.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Kattalist.API.Controllers
{
    public class ListaComprasController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<ListaCompras> _baseListaComprasService;

        public ListaComprasController(IMapper mapper, IBaseService<ListaCompras> baseListaComprasService) 
        {
            _mapper = mapper;
            _baseListaComprasService = baseListaComprasService;
        }

        [Route("api/[controller]")]

        // POST: ListaComprasController/Create
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<ListaCompras> Create([FromBody] ListaComprasDTO nomeLista)
        {
            try
            {
                var result = _baseListaComprasService.Add<ListaComprasValidator>(_mapper.Map<ListaCompras>(nomeLista));
                return Created("", result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
    }
}

