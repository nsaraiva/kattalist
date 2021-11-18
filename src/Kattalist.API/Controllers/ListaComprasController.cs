using AutoMapper;
using FluentValidation.Results;
using Kattalist.Domain.DTOs;
using Kattalist.Domain.Entities;
using Kattalist.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

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
            ListaComprasValidator validator = new ListaComprasValidator();
            ValidationResult result = validator.Validate(nomeLista);
            if (!result.IsValid)
            {
                string errorMessage = String.Empty;
                foreach (var failure in result.Errors)
                {
                    errorMessage += failure.ErrorMessage + "\n";
                }
                return BadRequest(errorMessage);
            }

            return Created("", _mapper.Map<ListaCompras>(nomeLista));
        }
    }
}

