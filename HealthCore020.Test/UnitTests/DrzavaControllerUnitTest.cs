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
    public class DrzavaControllerUnitTest
    {
        private readonly DrzavaService _service;
        public HealthCare020DbContext _dbContext;

        public DrzavaControllerUnitTest()
        {
            _dbContext = DbService.Instance.GetDbContext();
            HealthCore020DataDBInitializer.Seed_Drzave(_dbContext);

            _service = new DrzavaService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new HealthCare020.Core.Mappers.Mapper()))),
                _dbContext,
                new PropertyMappingService(),
                new PropertyCheckerService(),
                new HttpContextAccessor(),
                new AuthService(new HttpContextAccessor(), _dbContext));
        }

        #region Get By Id

        [Fact]
        public async void Task_GetPostById_Return_OkResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaId = 2;

            //Act
            var data = await controller.GetById(drzavaId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetDrzavaById_Return_NotFoundResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaId = 10;

            //Act
            var result = await controller.GetById(drzavaId);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async void Task_GetDrzavaById_Return_MatchResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaId = 1;

            //Act
            var data = await controller.GetById(drzavaId);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var drzava = okResult.Value.Should().BeAssignableTo<DrzavaDto>().Subject;

            Assert.Equal("TestNaziv1", drzava.Naziv);
            Assert.Equal("+123", drzava.PozivniBroj);
        }

        #endregion Get By Id

        #region Get All

        [Fact]
        public async void Task_GetDrzave_Return_OkResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            controller.SetFakeAuthenticatedControllerContext();

            //Act
            var data = await controller.Get(null);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetDrzave_Return_MatchResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            controller.SetFakeAuthenticatedControllerContext();

            //Act
            var data = await controller.Get(null);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var zdravstvenaStanja = okResult.Value.Should().BeOfType<List<DrzavaDto>>().Subject;

            Assert.Single(zdravstvenaStanja, item => item.Naziv.StartsWith("TestNaziv1"));
            Assert.Single(zdravstvenaStanja, item => item.Naziv.StartsWith("TestNaziv2"));
        }

        #endregion Get All

        #region Add New Drzava

        [Fact]
        public async void Task_Add_Drzava_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaUpsertRequest = new DrzavaUpsertRequest() { Naziv = "Bosna i Hercegovina" };

            //Act
            var data = await controller.Insert(drzavaUpsertRequest);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Add_Drzava_InvalidData_Return_ModelStateIsNotValid()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaUpsertRequest = new DrzavaUpsertRequest() { Naziv = "a" }; //Mora imati 3 ili vise slova

            //Act
            controller.ValidateViewModel(drzavaUpsertRequest);

            //Assert
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async void Task_Add_Drzava_ValidData_MatchResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaUpsertRequest = new DrzavaUpsertRequest() { Naziv = "Tur" }; //Mora imati 3 ili vise slova

            //Act
            var data = await controller.Insert(drzavaUpsertRequest);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<DrzavaDto>().Subject;

            Assert.Equal("Tur", result.Naziv);
        }

        #endregion Add New Drzava

        #region Update Existing Drzava

        [Fact]
        public async void Task_Update_Drzava_ValidData_Return_OkResult_MatchResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaId = 2;

            //Act
            var existingEntity = await controller.GetById(drzavaId);
            var okResult = existingEntity.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<DrzavaDto>().Subject;

            //Assert
            Assert.NotNull(result);

            //Act
            var drzava = new DrzavaUpsertRequest
            {
                Naziv = "UpdatedNaziv1",
                PozivniBroj = "UpdatedPozBr1"
            };

            var updatedData = await controller.Update(drzavaId, drzava);
            var okResultUpdated = updatedData.Should().BeOfType<OkObjectResult>().Subject;
            var resultUpdated = okResultUpdated.Value.Should().BeAssignableTo<DrzavaDto>().Subject;

            //Assert
            Assert.NotNull(resultUpdated);

            Assert.IsType<OkObjectResult>(updatedData);
            Assert.Equal("UpdatedNaziv1", resultUpdated.Naziv);
            Assert.Equal("UpdatedPozBr1", resultUpdated.PozivniBroj);
        }

        [Fact]
        public void Task_Update_Drzava_InvalidData_Return_ModelStateIsNotValid()
        {
            //Arrange
            var controller = new DrzavaController(_service);

            //Act
            var drzavaUpsertRequest = new DrzavaUpsertRequest() { Naziv = "A" }; //Mora imati 2 ili vise slova
            controller.ValidateViewModel(drzavaUpsertRequest);

            //Assert
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async void Task_Update_Drzava_InvalidId_Return_NotFound()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaId = 22;

            //Act
            var drzavaUpsertRequest = new DrzavaUpsertRequest() { Naziv = "Bugarska", PozivniBroj = "+03" };
            var result = await controller.Update(drzavaId, drzavaUpsertRequest);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        #endregion Update Existing Drzava

        #region Delete Zdravstveno Stanje

        [Fact]
        public async void Task_Delete_Drzava_Return_NoContentResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var id = 2;

            //Act
            var result = await controller.Delete(id);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Task_Delete_Drzava_Return_NotFound()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var id = 10;

            //Act
            var result = await controller.Delete(id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        #endregion Delete Zdravstveno Stanje
    }
}