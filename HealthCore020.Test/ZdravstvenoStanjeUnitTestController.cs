using AutoMapper;
using FluentAssertions;
using HealthCare020.API.Controllers;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;
using HealthCare020.Repository.Interfaces;
using HealthCare020.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace HealthCore020.Test
{
    public class ZdravstvenoStanjeUnitTestController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ZdravstvenoStanjeService _service;
        public static DbContextOptions<HealthCare020DbContext> dbContextOptions { get; set; }
        public static string connectionString = "Server=.;Database=Healthcare020_Test;Trusted_Connection=true;";

        static ZdravstvenoStanjeUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<HealthCare020DbContext>().UseSqlServer(connectionString).Options;
        }

        public ZdravstvenoStanjeUnitTestController()
        {
            var context = new HealthCare020DbContext(dbContextOptions);

            HealthCore020DataDBInitializer db = new HealthCore020DataDBInitializer();
            db.Seed(context);

            _unitOfWork = new UnitOfWork(context);
            _service = new ZdravstvenoStanjeService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new HealthCare020.Services.Mappers.Mapper()))),
                _unitOfWork);
        }

        #region Get By Id

        [Fact]
        public async void Task_GetPostById_Return_OkResult()
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
            var data = await controller.GetById(zdravstvenoStanjeId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
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
            var zdravstvenoStanje = okResult.Value.Should().BeAssignableTo<TwoFields>().Subject;

            Assert.Equal("TestOpis1", zdravstvenoStanje.Value);
        }

        #endregion Get By Id

        #region Get All

        [Fact]
        public async void Task_GetZdravstvenaStanja_Return_OkResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);

            //Act
            var data = await controller.Get(null);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetZdravstvenaStanja_Return_MatchResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);

            //Act
            var data = await controller.Get(null);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var zdravstvenaStanja = okResult.Value.Should().BeOfType<List<TwoFields>>().Subject;

            Assert.Equal("TestOpis1", zdravstvenaStanja[0].Value);
            Assert.Equal("TestOpis2", zdravstvenaStanja[1].Value);
        }

        #endregion Get All

        #region Add New ZdravstvenoStanje

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertRequest() { Opis = "Odlicno" };

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
            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertRequest() { Opis = "a" }; //Mora imati 3 ili vise slova

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
            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertRequest() { Opis = "Sjajno" }; //Mora imati 3 ili vise slova

            //Act
            var data = await controller.Insert(zdravstvenoStanjeUpsertRequest);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<TwoFields>().Subject;

            Assert.Equal("Sjajno", result.Value);
        }

        #endregion Add New ZdravstvenoStanje

        #region Update Existing ZdravstvenoStanje

        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var zdravstvenoStanjeId = 2;

            //Act
            var existingEntity = await controller.GetById(zdravstvenoStanjeId);
            var okResult = existingEntity.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<TwoFields>().Subject;

            Assert.NotNull(result);

            var zdravstvenoStanje = new ZdravstvenoStanjeUpsertRequest
            {
                Opis = "UpdatedOpis1"
            };

            var updatedData = controller.Update(zdravstvenoStanjeId, zdravstvenoStanje);

            //Assert
            Assert.IsType<OkObjectResult>(updatedData);
        }


        [Fact]
        public async void Task_Update_InvalidData_Return_ModelStateIsNotValid()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var zdravstvenoStanjeId = 2;

            var entity = await controller.GetById(zdravstvenoStanjeId);
            var okResult = entity.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<TwoFields>().Subject;

            Assert.NotNull(result);

            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertRequest() { Opis = "a" }; //Mora imati 3 ili vise slova

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

            var zdravstvenoStanjeUpsertRequest = new ZdravstvenoStanjeUpsertRequest() { Opis = "a" }; //Mora imati 3 ili vise slova

            var result = controller.Update(zdravstvenoStanjeId, zdravstvenoStanjeUpsertRequest);

            Assert.IsType<NotFoundResult>(result);
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
            var result =  controller.Delete(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async void Task_Delete_ZdravstvenoStanje_Return_NotFoundResult()
        {
            //Arrange
            var controller = new ZdravstvenoStanjeController(_service);
            var id = 10;

            //Act
            var result =  controller.Delete(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        
        #endregion
    }
}