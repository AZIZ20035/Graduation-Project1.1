using FacultySystem.Configurations;
using FacultySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultySystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Authentication1Controller : ControllerBase
    {
        private readonly AppDbContext Context;
        public Authentication1Controller(AppDbContext Context)
        {
            this.Context = Context;
        }

        [HttpGet]
        [Route("Registration")]

        public IActionResult Registration (string Email, string Name, bool Gender, string PhoneNumber, 
            string NationalId, int Year, string Password, int DepartmentId,bool type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check if this user is already registered as student
            Student st = new Student(Email, Name, Gender, PhoneNumber, NationalId, Year, Password, DepartmentId);
            var foundSt = Context.Students.FirstOrDefault(s => s.Email == st.Email);

            // check if this user is already registered as doctor
            Staff dr = new Staff(Email, Name, Gender, PhoneNumber, NationalId, Password);
            var foundDr = Context.Staffs.FirstOrDefault(s => s.Email == dr.Email);


            if (foundSt != null||foundDr!=null)
            {
                return BadRequest("This User is already exist");
            }

            // this is new user add it through target type
            if (type == true)
                Context.Students.Add(st);
            else
                Context.Staffs.Add(dr);

            Context.SaveChanges();
            return Ok("added Succesffuly");
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string Email, string Password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var st = Context.Students.FirstOrDefault(u=> u.Email==Email&&u.Password==Password);

            if(st!=null)
                return Ok("Student");

            var dr = Context.Staffs.FirstOrDefault(u => u.Email == Email && u.Password == Password);

            if(dr!=null)
                return Ok("Doctor");

            return BadRequest("user not found");
        }
    }
}
