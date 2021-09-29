using AutoMapper;
using Kattalist.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Kattalist.Domain.Validators;
using FluentValidation.Results;

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
                foreach(var failure in result.Errors)
                {
                    errorMessage += failure.ErrorMessage + "\n";
                }
                return BadRequest(errorMessage);
            }

            ListaCompras _nomeLista = new ListaCompras
            {
                Name = nomeLista.Name
            };

            return Created("", _mapper.Map<ListaCompras>(_nomeLista));
        }
    }
}

