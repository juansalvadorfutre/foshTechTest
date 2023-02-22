using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Domain.Builders;
using Sat.Recruitment.Domain.Dto;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerShould
    {
        private Fixture _fixture;
        private Mock<IUserRepository> _userRepositoryMock;
        private IEnumerable<User> _userRepositoryMockResult;
        private UsersController _sut;
        private UserDto _userDto;
        
        public UsersControllerShould()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            _userRepositoryMockResult = new List<User>() {
                new UserBuilder("Normal")
                            .WithName("Juan")
                            .WithEmail("Juan@marmol.com")
                            .WithPhone("+5491154762312")
                            .WithAddress("Peru 2464")
                            .WithUserType("Normal")
                            .WithMoney(decimal.Parse("1234"))
                            .Build(),
                new UserBuilder("Normal")
                            .WithName("Pedro")
                            .WithEmail("Pedro@gmail.com")
                            .WithPhone("687306441")
                            .WithAddress("Avenida America")
                            .WithUserType("Normal")
                            .WithMoney(decimal.Parse("20"))
                            .Build()
            };
            _userRepositoryMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(_userRepositoryMockResult);
            
            _sut = new UsersController(_userRepositoryMock.Object);

            _fixture = new Fixture();
            _userDto = _fixture.Create<UserDto>();
            _userDto.UserType = "Normal";
            _userDto.Money = "10";
            _userDto.Email = "dummyEmail@gmail.com";           
        }

        [Fact]
        public async void Return_BadRequest_When_The_Input_User_Email_Matches_With_Existing_User()
        {
            _userDto.Email = "Juan@marmol.com";

            var result = await _sut.CreateAsync(_userDto) as ObjectResult;
            
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("User is duplicated", result.Value);
        }

        [Fact]
        public async void Return_BadRequest_When_The_Input_User_Phone_Matches_With_Existing_User()
        {   
            _userDto.Phone = "+5491154762312";

            var result = await _sut.CreateAsync(_userDto) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("User is duplicated", result.Value);
        }

        [Fact]
        public async void Return_BadRequest_When_The_Input_Phone_And_Email_Are_Unique_But_Name_And_Address_Matches_With_Existing_User()
        {
            _userDto.Name = "Juan";
            _userDto.Address = "Peru 2464";

            var result = await _sut.CreateAsync(_userDto) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("User is duplicated", result.Value);
        }

        [Theory]
        [InlineData(null, "juan@gmail.com", "dummy street", "687306441", 1, "The name is required")]
        [InlineData("juan", null, "dummy street", "687306441", 1, "The Email is required")]
        [InlineData("juan", "juan@gmail.com", null, "687306441", 1, "The Address is required")]
        [InlineData("juan", "juan@gmail.com", "dummy street", null, 1, "The Phone is required")]
        public void Fail_Validation_When_Missing_Data(string name , string email, string address, string phone, int errorNumberExpected, string errorExpected)
        {
            _userDto.Name = name;
            _userDto.Email = email;
            _userDto.Address = address;
            _userDto.Phone = phone;

            var lstErrors = ValidateModel(_userDto);
            Assert.True(lstErrors.Count == errorNumberExpected);
            Assert.Contains(lstErrors, e => e.ErrorMessage == errorExpected);
        }

        [Fact]
        public async void Return_Success_When_The_Input_Data_Is_Not_Duplicated()
        {
            var result = await _sut.CreateAsync(_userDto) as ObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}