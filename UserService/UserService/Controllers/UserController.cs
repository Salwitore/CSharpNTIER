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

        public IActionResult GetUser([FromQuery]int UserId)
        {
            //return NoContent();
            try
            {
                return Ok(new UserBusiness().GetUser(UserId));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]

        public IActionResult DeleteUser(int UserId)
        {

            try
            {
                var user = new UserBusiness().DeleteUser(UserId);
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


        //DepartmentController

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(Department department)
        {
            try
            {
                new UserBusiness().AddDepartment(department);
                return Created("", department);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteDepartment")]
        public IActionResult DeleteDepartment(int departmentId)
        {
            try
            {
                return Ok(new UserBusiness().DeleteDepartment(departmentId));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDepartments")]
        public IActionResult GetDepartments()
        {
            return Ok(new UserBusiness().GetDepartments());
        }

        [HttpGet("GetDepartment")]
        public IActionResult GetDepartment(int departmentId)
        {
            try
            {
                return Ok(new UserBusiness().GetDepartment(departmentId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        [HttpGet("GetDepartmentsOnSameFloor")]
        public IActionResult GetDepartmentsOnSameFloor(int floorNum)
        {
            try
            {
                return Ok(new UserBusiness().GetDepartmentsOnSameFloor(floorNum));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUsersInSameDepartments")]
        public IActionResult GetUsersInSameDepartments(int departmentId)
        {
            try
            {
                return Ok(new UserBusiness().GetUsersInSameDepartment(departmentId));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

    }
}