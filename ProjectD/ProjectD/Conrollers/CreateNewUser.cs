using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectD.Data.Models;
using ProjectD.Models;

namespace ProjectD.Conrollers
{
    [Route("api/[controller]")]
        
    public class CreateNewUserController : Controller
    {
        private readonly ApplicationContext _dbContext;

        public CreateNewUserController(ApplicationContext dbContext)
        {
            _dbContext = dbContext; 
        }
        
        [HttpPost("RegisterUser")]  
        public IActionResult RegisterUser([FromBody]UserModel user)
         {
            
            User person = _dbContext.Users.FirstOrDefault(f=> f.Name == user.name && f.surname == user.surname);
                        
            if (person == null)
            {   
                var newuser = new User
                {

                    Name = user.name,
                    surname = user.surname,
                    Email = user.email,
                    Password = user.password
                };
                _dbContext.Users.Add(newuser);
                _dbContext.SaveChanges();

                return Ok("Registartion completed ");
            }
            else
            {
                return BadRequest("User already exist"); 
            }
        }
        [HttpGet("GetUser")]
        public IActionResult GetUser(string name, string pass) 
        {
            var user = _dbContext.Users.FirstOrDefault(f=>f.Name == name && f.Password == pass);
            if (user is not null)
            {
                var res = new UserModel {
                    name = user.Name,
                    surname = user.surname,
                    email = user.Email
                };
            return Ok(user);
            }
            else
            {
                return NotFound("User not found");
            }
        }
    }
}









