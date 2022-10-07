using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {   
        //Presentation
         

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(new UserBusiness().GetUsers());
        }

        [HttpGet("GetYoungUser")]

        public IActionResult GetYoungUsers()
        {
            return Ok(new UserBusiness().GetYoungUsers());
        }

        [HttpGet("GetAdultUser")]

        public IActionResult GetAdultUsers()
        {
            return Ok(new UserBusiness().GetAdultUsers());
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {

            try
            {
                new UserBusiness().AddUser(user);
                return Created("", user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetUser")]

        public IActionResult GetUser([FromQuery]int id)
        {
            //return NoContent();
            try
            {
                return Ok(new UserBusiness().GetUser(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]

        public IActionResult DeleteUser(int id)
        {

            try
            {
                var user = new UserBusiness().DeleteUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        [HttpGet("AddWordUsersName")]

        public IActionResult AddWordUsersName(string word)
        {
            return Ok(new UserBusiness().AddWordUsersName(word));
        }
    

    }
}