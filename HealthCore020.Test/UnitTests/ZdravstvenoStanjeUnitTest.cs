using AutoMapper;
using FluentAssertions;
using HealthCare020.API.Controllers;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;
using HealthCare020.Services;
using HealthCare020.Services.Services;
using HealthCore020.Test.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace HealthCore020.Test.UnitTests
{
    public class ZdravstvenoStanjeUnitTest
    {
        private readonly ZdravstvenoStanjeService _service;
        public HealthCare020DbContext _dbContext;

        public ZdravstvenoStanjeUnitTest()
        {
            _dbContext = DbService.Instance.GetDbContext();
            _service = new ZdravstvenoStanjeService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new HealthCare020.Services.Mappers.Mapper()))),
                _dbContext,
                new PropertyMappingService(),
                new PropertyCheckerService(),
                new HttpContextAccessor(),
                new AuthService(new HttpContextAccessor(), _dbContext));

            HealthCore020DataDBInitializer.Seed_ZdravstvenoStanje(_dbContext);
        }

        #region Get By Id

        [Fact]
        public async void Task_GetZdravstvenoStanjeById_Return_OkResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var zdravstvenoStanjeId = 2;

            //Act
            var data = await controller.GetById(zdravstvenoStanjeId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetZdravstvenoStanjeById_Return_NotFoundResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var zdravstvenoStanjeId = 10;

            //Act
            var result = await controller.GetById(zdravstvenoStanjeId);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async void Task_GetZdravstvenoStanjeById_Return_MatchResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var zdravstvenoStanjeId = 1;

            //Act
            var data = await controller.GetById(zdravstvenoStanjeId);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var zdravstvenoStanje = okResult.Value.Should().BeAssignableTo<ZdravstvenoStanjeDto>().Subject;

            Assert.Equal("TestOpis1", zdravstvenoStanje.Opis);
        }

        #endregion Get By Id

        #region Get All

        [Fact]
        public async void Task_GetZdravstvenaStanja_Return_OkResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            controller.SetFakeAuthenticatedControllerContext();

            //Act
            var data = await controller.Get(null);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var serviceResult = okResult.Value.Should().BeOfType<List<ZdravstvenoStanjeDto>>().Subject;

            Assert.Equal(6, serviceResult?.Count ?? 0);
        }

        [Fact]
        public async void Task_GetZdravstvenaStanja_Return_MatchResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            controller.SetFakeAuthenticatedControllerContext();

            //Act
            var data = await controller.Get(null);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var zdravstvenaStanja = okResult.Value.Should().BeOfType<List<ZdravstvenoStanjeDto>>().Subject;

            Assert.Equal("TestOpis1", zdravstvenaStanja[0].Opis);
            Assert.Equal("TestOpis2", zdravstvenaStanja[1].Opis);
        }

        #endregion Get All

        #region Add New ZdravstvenoStanje

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            controller.SetFakeAuthenticatedControllerContext();
            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertDto() { Opis = "Odlicno" };

            //Act
            var data = await controller.Insert(zdravstvenoStanjeUpsertRequest);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_ModelStateIsNotValid()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertDto() { Opis = "a" }; //Mora imati 3 ili vise slova

            //Act
            controller.ValidateViewModel(zdravstvenoStanjeUpsertRequest);

            //Assert
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async void Task_Add_ValidData_MatchResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertDto() { Opis = "Sjajno" };

            //Act
            var data = await controller.Insert(zdravstvenoStanjeUpsertRequest);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<ZdravstvenoStanjeDto>().Subject;

            Assert.Equal("Sjajno", result.Opis);
        }

        #endregion Add New ZdravstvenoStanje

        #region Update Existing ZdravstvenoStanje

        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            controller.SetFakeAuthenticatedControllerContext();

            var zdravstvenoStanjeId = 2;

            //Act
            var existingEntity = await controller.GetById(zdravstvenoStanjeId);
            var okResult = existingEntity.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<ZdravstvenoStanjeDto>().Subject;

            //Assert
            Assert.NotNull(result);

            var zdravstvenoStanje = new ZdravstvenoStanjeUpsertDto
            {
                Opis = "UpdatedOpis1"
            };

            var updatedData = await controller.Update(zdravstvenoStanjeId, zdravstvenoStanje);
            Assert.IsType<OkObjectResult>(updatedData);

            var okResultOfUpdate = updatedData.Should().BeOfType<OkObjectResult>().Subject;
            var resultOfUpdate = okResultOfUpdate.Value.Should().BeAssignableTo<ZdravstvenoStanjeDto>().Subject;

            Assert.Equal("UpdatedOpis1", resultOfUpdate.Opis);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_ModelStateIsNotValid()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            controller.SetFakeAuthenticatedControllerContext();

            var zdravstvenoStanjeId = 2;
            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertDto() { Opis = "a" }; //Mora imati 3 ili vise slova

            //Act
            controller.ValidateViewModel(zdravstvenoStanjeUpsertRequest);

            //Assert
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_NotFound()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var zdravstvenoStanjeId = 10;

            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertDto() { Opis = "aaaaa" };

            //Act
            var result = await controller.Update(zdravstvenoStanjeId, zdravstvenoStanjeUpsertRequest);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        #endregion Update Existing ZdravstvenoStanje

        #region Delete Zdravstveno Stanje

        [Fact]
        public async void Task_Delete_ZdravstvenoStanje_Return_OkResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var id = 2;

            //Act
            var result = await controller.Delete(id);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Task_Delete_ZdravstvenoStanje_Return_NotFound()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var id = 10;

            //Act
            var result = await controller.Delete(id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        #endregion Delete Zdravstveno Stanje
    }
}