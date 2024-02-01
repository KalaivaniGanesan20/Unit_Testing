using System.Net;
using Api;
using Api.Controllers;
using AppController;
using Database;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Service;
using UserModel;
using UserServices;
namespace test;

public class UnitTest1
{
    private readonly WeatherForecastController _weather;
     private readonly IUser _userservice;
    private readonly UserController _user;
    private readonly ApplicationDbcontext _appdb;


    public UnitTest1()
    {
        _weather=new WeatherForecastController();

        var options=new DbContextOptionsBuilder<ApplicationDbcontext>().UseInMemoryDatabase(databaseName:"Testing").Options;
        _appdb=new ApplicationDbcontext(options);
        _userservice=new UserService(_appdb);
        _user=new UserController(_userservice);
        
    }

    [Fact]
    public void Test1()
    {
       //Arrange

       //Act
       var result=_weather.Get();
       var result_type=result as OkObjectResult;
       var list=result_type?.Value as List<WeatherForecast>;

       //Assert
       Assert.NotNull(result);
       Assert.Equal(5,result.Count());
    }

    [Fact]
    
    public void PostTest()
    {
         //Arrange
         User user=new User()
         {
            username="deepa",
            emailid="deepag65792@gmail.com"
         };
         //Act
         var response=_user.PostUser(user);
         var createdresponse=response as CreatedAtActionResult;
         var data=createdresponse?.Value as User;
         //Assert
         Assert.IsType<CreatedAtActionResult>(response);
         Assert.NotNull(response);
         Assert.Equal("deepa",data.username);
    }

    [Theory]
    //[InlineData(10)]
    //[InlineData(30)]
    [InlineData(100)]
    public void TestCalculateMethod(int value)
    {
        var response=_user.Calculate(value);

        //Assert.Equal("value is less than 20",response);
       Assert.Equal("value is above limit",response);

      
    }

    [Fact]
    public void DeleteTest()
    {
        //Arrange

        int invalid_Id=100;
        int valid_Id=3;

       //Act

        var errorresult=_user.DeleteUser(invalid_Id);
        var errortype=errorresult as NotFoundObjectResult;
        var successresult=_user.DeleteUser(valid_Id);
        var successtype=successresult as OkObjectResult;


       //Assert
       
         Assert.NotNull(errortype);
         Assert.NotNull(successtype);
         
    }
}