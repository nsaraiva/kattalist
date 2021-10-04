using AutoMapper;
using Kattalist.Domain.Entities;
using Kattalist.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Kattalist.Test
{
    public class ListaComprasControllerUnitTest
    {
        public static IEnumerable<object[]> CorrectNameSyntax =>
            new List<object[]>
            {
                new object[] {new ListaCompras { Name = "Test"}},
                new object[] {new ListaCompras { Name = "123Test"}},
                new object[] {new ListaCompras { Name = "Test123"}},
                new object[] {new ListaCompras { Name = "123"}},                
            };

        public static IEnumerable<object[]> IncorrectNameSyntax =>
            new List<object[]>
            {
                        new object[] {new ListaCompras { Name = ""}},
                        new object[] {new ListaCompras { Name = " "}},
                        new object[] {new ListaCompras { Name = " Test"}},
                        new object[] {new ListaCompras { Name = "Test "}},
                        new object[] {new ListaCompras { Name = "Tes t"}}
            };

        [Theory]
        [MemberData(nameof(CorrectNameSyntax))]
        [MemberData(nameof(CorrectNameSyntax))]
        public void CreatePostShouldRerturnListaComprasIfNameIsInCorrectFormat(ListaCompras nomeLista)
        {
            //AutoMapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            //Arrange
            var controller = new ListaComprasController(mapper: mapper);

            //Act
            ActionResult<ListaComprasDTO> listaCompras = controller.Create(nomeLista);

            //Assert
            Assert.NotNull(listaCompras);

            var response = listaCompras.Result as ObjectResult;

            Assert.Equal((int)HttpStatusCode.Created, response.StatusCode);

            var values = ((ObjectResult)listaCompras.Result).Value;
            Assert.True(Guid.TryParse(((BaseEntity)values).Id.ToString(), out var newGuid));
            Assert.True(DateTime.TryParse(((BaseEntity)values).DataCriacao.ToString(), out DateTime teste));
            Assert.Equal(nomeLista.Name, ((ListaComprasDTO)values).Name);
        }

        [Theory]
        [MemberData(nameof(IncorrectNameSyntax))]
        public void CreatePostShouldRerturnCode400IfNameIsInIncorrectFormat(ListaCompras nomeLista)
        {
            //AutoMapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            //Arrange
            var controller = new ListaComprasController(mapper: mapper);

            //Act
            ActionResult<ListaComprasDTO> listaCompras = controller.Create(nomeLista);

            //Assert
            Assert.NotNull(listaCompras);

            var response = listaCompras.Result as ObjectResult;
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
