﻿using AutoMapper;
using FluentValidation.Results;
using Kattalist.Domain.DTOs;
using Kattalist.Domain.Entities;
using Kattalist.Domain.Interfaces;
using Kattalist.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Kattalist.API.Controllers
{
    public class GroceryListController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<GroceryList> _baseGroceryListService;

        public GroceryListController(IMapper mapper, IBaseService<GroceryList> baseListaComprasService) 
        {
            _mapper = mapper;
            _baseGroceryListService = baseListaComprasService;
        }

        [Route("api/[controller]/lists")]
        [HttpGet]
        public ActionResult<List<GroceryListGetDTO>> GetLists()
        {
            return Ok(_mapper.Map<List<GroceryListGetDTO>>(_baseGroceryListService.Get()));
        }

        [Route("api/[controller]/list")]
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<GroceryList> Create([FromBody] GroceryListPostDTO listName)
        {
            try
            {
                var result = _baseGroceryListService.Add<GroceryListValidator>(_mapper.Map<GroceryList>(listName));
                return Created("", result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
    }
}
