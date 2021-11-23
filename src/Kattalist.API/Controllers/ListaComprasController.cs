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
            var result = _baseListaComprasService.Add<ListaComprasValidator>(_mapper.Map<ListaCompras>(nomeLista));

            //if (!result.IsValid)
            //{
            //    string errorMessage = String.Empty;
            //    foreach (var failure in result.Errors)
            //    {
            //        errorMessage += failure.ErrorMessage + "\n";
            //    }
            //    return BadRequest(errorMessage);
            //}

            return Created("", result);
        }
    }
}

