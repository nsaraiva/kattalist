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
using System.Collections.Generic;


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
            GroceryListPostDTO listName = new GroceryListPostDTO()
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
        public void CreatePostShouldRerturnCode400IfNameIsInWrongFormat()
        {
            var _mapper = AutoMapperConfiguration();

            GroceryListPostDTO listName = new GroceryListPostDTO()
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

        [Fact]
        public void GetListsShouldReturnAllGroceryLists()
        {
            var _mapper = AutoMapperConfiguration();
            var mockServ = new Mock<IBaseService<GroceryList>>();
            mockServ.Setup(serv => serv.Get()).Returns(mockServ.Object.Get());

            var controller = new GroceryListController(_mapper, mockServ.Object);

            //Act
            ActionResult<List<GroceryListGetDTO>> listaCompras = controller.GetLists();

            //Assert
            var response = listaCompras.Result as ObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }
    }
}
