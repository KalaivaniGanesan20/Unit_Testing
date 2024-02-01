using Microsoft.AspNetCore.Mvc;
using UserModel;
using UserServices;

namespace AppController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUser _userservice;
        public UserController(IUser userservice)
        {
           _userservice=userservice;
        }
       [HttpGet]
       public ActionResult<List<User>> GetUser()
       {
          var data= _userservice.GetUser();
          if(data==null)
          {
            return BadRequest();
          }
          return Ok(data);
       }
       [HttpPost]
       public ActionResult PostUser(User user)
       {
           var data=_userservice.PostUser(user);
           return CreatedAtAction("GetUser",data);

       }

       [HttpDelete("{id}")]
       public IActionResult DeleteUser(int id)
       {
          var value=_userservice.DeleteUser(id);
          if(value==true)
          {
            return Ok("User deleted");
          }
          else
          {
            return NotFound("User Notfound");
          }
       }

       [HttpPost("{value}")]
       public string Calculate(int value)
       {
         if(value<20)
         {
            return "value is less than 20";
         }
         else if(value<40 && value>20)
         {
            return "value is less than 40";
         }
         else
         {
            return "value is above limit";
         }
       }
    }
}