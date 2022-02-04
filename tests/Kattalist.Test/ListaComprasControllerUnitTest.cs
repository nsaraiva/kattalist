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
            ListaComprasDTO nomeLista = new ListaComprasDTO()
            {
                Name = "Teste2"
            };

            var mockServ = new Mock<IBaseService<ListaCompras>>();
            mockServ.Setup(serv => serv.Add<ListaComprasValidator>(It.IsAny<ListaCompras>())).Returns(_mapper.Map<ListaCompras>(nomeLista));

            var controller = new ListaComprasController(_mapper, mockServ.Object);

            //Act
            ActionResult<ListaCompras> listaCompras = controller.Create(nomeLista);

            //Assert
            Assert.NotNull(listaCompras);

            var response = listaCompras.Result as ObjectResult;

            Assert.Equal((int)HttpStatusCode.Created, response.StatusCode);

            //var values = ((ObjectResult)listaCompras.Result).Value;
            Assert.True(Guid.TryParse(((BaseEntity)response.Value).Id.ToString(), out var newGuid));
            Assert.True(DateTime.TryParse(((BaseEntity)response.Value).DataCriacao.ToString(), out DateTime teste));
            Assert.Equal(nomeLista.Name, ((ListaCompras)response.Value).Name);
        }

        [Fact]
        public void CreatePostShouldRerturnCode400IfNameIsInwrongFormat()
        {
            var _mapper = AutoMapperConfiguration();

            ListaComprasDTO nomeLista = new ListaComprasDTO()
            {
                Name = ""
            };

            var mockServ = new Mock<IBaseService<ListaCompras>>();
            mockServ.Setup(serv => serv.Add<ListaComprasValidator>(It.IsAny<ListaCompras>())).Returns(_mapper.Map<ListaCompras>(nomeLista));

            var controller = new ListaComprasController(_mapper, mockServ.Object);

            //Act
            ActionResult<ListaCompras> listaCompras = controller.Create(nomeLista);

            //Assert
            var response = listaCompras.Result as ObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);

        }
    }
}
