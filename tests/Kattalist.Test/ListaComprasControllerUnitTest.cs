using AutoMapper;
using Kattalist.API.Controllers;
using Kattalist.Domain.DTOs;
using Kattalist.Domain.Entities;
using Kattalist.Domain.Interfaces;
using Kattalist.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using Xunit;
using FluentValidation.TestHelper;

namespace Kattalist.Test
{
    public class ListaComprasControllerUnitTest
    {
        private IMapper AutoMapperConfiguration()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            return mockMapper.CreateMapper();
        }

        [Fact]
        public void CreatePostShouldRerturnListaComprasIfNameIsInCorrectFormat()
        {
            var _mapper = AutoMapperConfiguration();

            //Arrange
            GroceryListDTO listName = new GroceryListDTO()
            {
                Name = "Teste2"
            };

            GroceryListValidator validator = new GroceryListValidator();

            validator.Validate(_mapper.Map<GroceryList>(listName));

            var mockServ = new Mock<IBaseService<GroceryList>>();
            mockServ.Setup(serv => serv.Add<GroceryListValidator>(It.IsAny<GroceryList>())).Returns(_mapper.Map<GroceryList>(listName));

            var controller = new GroceryListController(_mapper, mockServ.Object);

            //Act
            ActionResult<GroceryList> listaCompras = controller.Create(listName);

            //Assert
            Assert.NotNull(listaCompras);

            var response = listaCompras.Result as ObjectResult;

            Assert.Equal((int)HttpStatusCode.Created, response.StatusCode);

            //var values = ((ObjectResult)listaCompras.Result).Value;
            //Assert.True(Guid.TryParse(((BaseEntity)response.Value).Id.ToString(), out var newGuid));
            Assert.True(DateTime.TryParse(((BaseEntity)response.Value).CreatedDate.ToString(), out DateTime teste));
            Assert.Equal(listName.Name, ((GroceryList)response.Value).Name);
        }

        [Fact]
        public void CreatePostShouldRerturnCode400IfNameIsInwrongFormat()
        {
            var _mapper = AutoMapperConfiguration();

            GroceryListDTO listName = new GroceryListDTO()
            {
                Name = ""
            };

            var mockServ = new Mock<IBaseService<GroceryList>>();
            mockServ.Setup(serv => serv.Add<GroceryListValidator>(It.IsAny<GroceryList>())).Returns(_mapper.Map<GroceryList>(listName));

            var controller = new GroceryListController(_mapper, mockServ.Object);

            //Act
            ActionResult<GroceryList> listaCompras = controller.Create(listName);

            //Assert
            var response = listaCompras.Result as ObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);

        }
    }
}
