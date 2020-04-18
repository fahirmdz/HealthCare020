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
using System.Collections.Generic;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Services;
using Xunit;

namespace HealthCore020.Test
{
    public class KorisnikUnitTestController
    {
        private readonly KorisnikService _service;
        public static DbContextOptions<HealthCare020DbContext> dbContextOptions { get; set; }
        public static string connectionString = "Server=.;Database=Healthcare020_Test;Trusted_Connection=true;";

        static KorisnikUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<HealthCare020DbContext>().UseSqlServer(connectionString).Options;
        }

        public KorisnikUnitTestController()
        {
            var context = new HealthCare020DbContext(dbContextOptions);

            HealthCore020DataDBInitializer db = new HealthCore020DataDBInitializer();
            db.Seed_Korisnik(context);

            _service = new KorisnikService( new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new HealthCare020.Services.Mappers.Mapper()))),context,
                new PropertyMappingService(), new PropertyCheckerService());
        }

        #region Get By Id

        [Fact]
        public async void Task_GetKorisnikById_Return_OkResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogId = 2;

            //Act
            var data = await controller.GetById(korisnickiNalogId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetKorisnikById_Return_NotFoundResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogId = 10;

            //Act
            NotFoundException ex = await Assert.ThrowsAsync<NotFoundException>(() =>
             {
                 return controller.GetById(korisnickiNalogId);
             });

            //Assert
            Assert.Equal("Korisnicki nalog nije pronadjen", ex.Message);
        }

        [Fact]
        public async void Task_GetKorisnikById_Return_MatchResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogId = 1;

            //Act
            var data = await controller.GetById(korisnickiNalogId);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<KorisnickiNalogDto>().Subject;

            //Assert
            Assert.Equal("testuser1", result.Username);
        }

        #endregion Get By Id

        #region Get All

        [Fact]
        public async void Task_GetKorisnici_Return_OkObjectResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);

            //Act
            var data = await controller.Get(new KorisnickiNalogResourceParameters());

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetKorisnici_Return_MatchResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogSearchRequest = new KorisnickiNalogResourceParameters { Username = "testuser1" };

            //Act
            var data = await controller.Get(korisnickiNalogSearchRequest);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<List<KorisnickiNalogDto>>().Subject;

            //Assert
            Assert.Equal("testuser1", result[0].Username);
        }

        #endregion Get All

        #region Add New KorisnickiNalog

        [Fact]
        public async void Task_Add_ValidData_Return_OkObjectResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogInsertRequest = new KorisnickiNalogUpsertDto
            {
                Username = "test2020",
                Password = "testpw",
                ConfirmPassword = "testpw"
            };

            //Act
            var data = await controller.Insert(korisnickiNalogInsertRequest);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_InvalidModelState()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogInsertRequest = new KorisnickiNalogUpsertDto
            {
                Username = "test2020",
                Password = "test",   //Invalid data -> minimum 6 characters
                ConfirmPassword = "test"
            };

            //Act
            controller.ValidateViewModel(korisnickiNalogInsertRequest);

            //Assert
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async void Task_Add_InvalidData_Throw_UserException()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogInsertRequest = new KorisnickiNalogUpsertDto
            {
                Username = "test2020",
                Password = "different", //should be same
                ConfirmPassword = "pws" //should be same
            };

            //Act
            UserException ex = await Assert.ThrowsAsync<UserException>(() => controller.Insert(korisnickiNalogInsertRequest));

            //Assert
            Assert.Equal("Lozinke se ne podudaraju", ex.Message);
        }

        [Fact]
        public async void Task_Add_ValidData_Return_MatchResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogInsertRequest = new KorisnickiNalogUpsertDto
            {
                Username = "test2020",
                Password = "test1111",
                ConfirmPassword = "test1111"
            };

            //Act
            var data = await controller.Insert(korisnickiNalogInsertRequest);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<KorisnickiNalogDto>().Subject;

            //Assert
            Assert.Equal("test2020", result.Username);
        }

        #endregion Add New KorisnickiNalog

        #region Update Existing KorisnickiNalog

        [Fact]
        public async void Task_Update_ValidData_Return_OkObjectResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogInsertRequest = new KorisnickiNalogUpsertDto
            {
                Username = "testtest",
                Password = "test1111",
                ConfirmPassword = "test1111"
            };

            //Act
            var data = controller.Update(1, korisnickiNalogInsertRequest);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_InvalidModelState()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogInsertRequest = new KorisnickiNalogUpsertDto
            {
                Username = "testtest",
                Password = "lowe", //should be at least 6 characters
                ConfirmPassword = "lowe"
            };

            //Act
            controller.ValidateViewModel(korisnickiNalogInsertRequest);

            //Assert
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async void Task_Update_InvalidData_Throw_UserException()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogInsertRequest = new KorisnickiNalogUpsertDto
            {
                Username = "testtest",
                Password = "loeeee", //razlicite lozinke
                ConfirmPassword = "loerererer"
            };

            //Act
            UserException ex = Assert.Throws<UserException>(() => controller.Update(1, korisnickiNalogInsertRequest));

            //Assert
            Assert.Equal("Lozinke se ne podudaraju", ex.Message);
        }

        [Fact]
        public async void Task_Update_ValidData_Return_MatchResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogInsertRequest = new KorisnickiNalogUpsertDto
            {
                Username = "test2020",
                Password = "test1111",
                ConfirmPassword = "test1111"
            };

            //Act
            var data = controller.Update(1, korisnickiNalogInsertRequest);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<KorisnickiNalogDto>().Subject;

            //Assert
            Assert.Equal("test2020", result.Username);
        }

        [Fact]
        public async void Task_Update_ValidData_Throw_NotFoundException()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogId = 10;
            var korisnickiNalogInsertRequest = new KorisnickiNalogUpsertDto
            {
                Username = "test2020",
                Password = "test1111",
                ConfirmPassword = "test1111"
            };

            //Act
            NotFoundException ex = Assert.Throws<NotFoundException>(() =>
            {
                controller.Update(korisnickiNalogId, korisnickiNalogInsertRequest);
            });

            //Assert
            Assert.Equal("Korisnicki nalog nije pronadjen", ex.Message);
        }

        #endregion Update Existing KorisnickiNalog

        #region Delete Korisnicki nalog

        [Fact]
        public async void Task_Delete_KorisnickiNalog_Return_OkResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var id = 2;

            //Act
            var result = controller.Delete(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_Delete_KorisnickiNalog_Throw_NotFoundException()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogId = 10;

            //Act
            NotFoundException ex = Assert.Throws<NotFoundException>(() =>
            {
                controller.Delete(korisnickiNalogId);
            });

            //Assert
            Assert.Equal("Korisnicki nalog nije pronadjen", ex.Message);
        }

        #endregion Delete Korisnicki nalog
    }
}