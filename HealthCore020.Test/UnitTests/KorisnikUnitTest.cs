using AutoMapper;
using FluentAssertions;
using HealthCare020.API.Controllers;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services;
using HealthCare020.Services.Services;
using HealthCore020.Test.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.DataProtection;
using Xunit;

namespace HealthCore020.Test.UnitTests
{
    public class KorisnikUnitTest
    {
        private readonly KorisnikService _service;
        public HealthCare020DbContext _dbContext;

        public KorisnikUnitTest()
        {
            _dbContext = DbService.Instance.GetDbContext();
            HealthCore020DataDBInitializer.Seed_Korisnik(_dbContext);

            _service = new KorisnikService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new HealthCare020.Core.Mappers.Mapper()))),
                _dbContext,
                new PropertyMappingService(),
                new PropertyCheckerService(),
                new HttpContextAccessor(),
                new SecurityService(),
                new AuthService(new HttpContextAccessor(),_dbContext),new CipherService(new EphemeralDataProtectionProvider()),
                new FaceRecognitionService());
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
            var result = await controller.GetById(korisnickiNalogId);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
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
            var result = okResult.Value.Should().BeAssignableTo<KorisnickiNalogDtoLL>().Subject;

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
            controller.SetFakeAuthenticatedControllerContext();

            //Act
            var data = await controller.Get(null);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetKorisnici_Return_MatchResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            controller.SetFakeAuthenticatedControllerContext();
            var korisnickiNalogSearchRequest = new KorisnickiNalogResourceParameters { Username = "testuser1" };

            //Act
            var data = await controller.Get(korisnickiNalogSearchRequest);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<List<KorisnickiNalogDtoLL>>().Subject;

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
        public void Task_Add_InvalidData_Return_InvalidModelState()
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
            var result = await controller.Insert(korisnickiNalogInsertRequest);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
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
            var result = okResult.Value.Should().BeAssignableTo<KorisnickiNalogDtoLL>().Subject;

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
            var data = await controller.Update(1, korisnickiNalogInsertRequest);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }


        [Fact]
        public async void Task_Update_InvalidId_Return_NotFoundObjectResult()
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
            var result = await controller.Update(50, korisnickiNalogInsertRequest);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
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
            var data = await controller.Update(1, korisnickiNalogInsertRequest);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<KorisnickiNalogDtoLL>().Subject;

            //Assert
            Assert.Equal("test2020", result.Username);
        }

        #endregion Update Existing KorisnickiNalog

        #region Delete Korisnicki nalog

        [Fact]
        public async void Task_Delete_KorisnickiNalog_Return_NoContentResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var id = 2;

            //Act
            var result = await controller.Delete(id);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Task_Delete_KorisnickiNalog_Return_NotFoundObjectResult()
        {
            //Arrange
            var controller = new KorisnikController(_service);
            var korisnickiNalogId = 10;

            //Act
            var result = await controller.Delete(korisnickiNalogId);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        #endregion Delete Korisnicki nalog
    }
}