using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using HealthCare020.API.Controllers;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;
using HealthCare020.Services;
using HealthCare020.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HealthCore020.Test
{
    public class DrzavaControllerUnitTestController
    {
        private readonly DrzavaService _service;
        public static DbContextOptions<HealthCare020DbContext> dbContextOptions { get; set; }
        public static string connectionString = "Server=.;Database=Healthcare020_Test;Trusted_Connection=true;";

        static DrzavaControllerUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<HealthCare020DbContext>().UseSqlServer(connectionString).Options;
        }

        public DrzavaControllerUnitTestController()
        {
            var context = new HealthCare020DbContext(dbContextOptions);

            HealthCore020DataDBInitializer db = new HealthCore020DataDBInitializer();
            db.Seed_Drzave(context);

            _service = new DrzavaService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new HealthCare020.Services.Mappers.Mapper()))),context);
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
            NotFoundException ex = await Assert.ThrowsAsync<NotFoundException>(() => controller.GetById(drzavaId));

            //Assert
            Assert.Equal("Not Found", ex.Message);
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
            var drzava = okResult.Value.Should().BeAssignableTo<DrzavaModel>().Subject;

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

            //Act
            var data = await controller.Get(null);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var zdravstvenaStanja = okResult.Value.Should().BeOfType<List<DrzavaModel>>().Subject;

            Assert.Equal("TestNaziv1", zdravstvenaStanja[0].Naziv);
            Assert.Equal("TestNaziv2", zdravstvenaStanja[1].Naziv);
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
            var result = okResult.Value.Should().BeAssignableTo<DrzavaModel>().Subject;

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
            var result = okResult.Value.Should().BeAssignableTo<DrzavaModel>().Subject;

            Assert.NotNull(result);

            var drzava = new DrzavaUpsertRequest
            {
                Naziv = "UpdatedNaziv1",
                PozivniBroj = "UpdatedPozBr1"
            };

            var updatedData = controller.Update(drzavaId, drzava);
            var okResultUpdated = updatedData.Should().BeOfType<OkObjectResult>().Subject;
            var resultUpdated = okResultUpdated.Value.Should().BeAssignableTo<DrzavaModel>().Subject;

            //Assert
            Assert.IsType<OkObjectResult>(updatedData);
            Assert.Equal("UpdatedNaziv1",resultUpdated.Naziv);
            Assert.Equal("UpdatedPozBr1",resultUpdated.PozivniBroj);

        }


        [Fact]
        public async void Task_Update_Drzava_InvalidData_Return_ModelStateIsNotValid()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaId = 2;

            var entity = await controller.GetById(drzavaId);
            var okResult = entity.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<DrzavaModel>().Subject;

            Assert.NotNull(result);

            var drzavaUpsertRequest = new DrzavaUpsertRequest() { Naziv = "A" }; //Mora imati 2 ili vise slova

            //Act
            controller.ValidateViewModel(drzavaUpsertRequest);

            //Assert
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async void Task_Update_Drzava_InvalidData_Return_NotFound()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var drzavaId = 10;

            var drzavaUpsertRequest = new DrzavaUpsertRequest() { Naziv = "Bugarska",PozivniBroj ="+03"}; 

            //Act
            NotFoundException ex =  Assert.Throws<NotFoundException>(() => controller.Update(drzavaId,drzavaUpsertRequest));

            //Assert
            Assert.Equal("Not Found", ex.Message);
        }

        #endregion Update Existing Drzava

        #region Delete Zdravstveno Stanje

        [Fact]
        public async void Task_Delete_Drzava_Return_OkResult()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var id = 2;

            //Act
            var result =  controller.Delete(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async void Task_Delete_Drzava_Return_NotFound()
        {
            //Arrange
            var controller = new DrzavaController(_service);
            var id = 10;

            //Act
            NotFoundException ex =  Assert.Throws<NotFoundException>(() => controller.Delete(id));

            //Assert
            Assert.Equal("Not Found", ex.Message);
        }
        
        #endregion


    }
}