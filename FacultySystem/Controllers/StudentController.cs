using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FacultySystem.Configurations;
using FacultySystem.DTOs;
using FacultySystem.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;


namespace FacultySystem.Controllers
{
    [ApiController]
    //[Route("api/Student")]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterStudentDto request)
        {
           

            if (_context.Students.Any(s => s.Email == request.Email))
            {
                return BadRequest(new { error = "Email already exists" });
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var student = new Student
            {
                
                Name = request.FullName,
                Email = request.Email,
                Password = hashedPassword,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                NationalId = request.NationalId,
                DepartmentId = 1
             
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Created("", new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == request.Email);

            if (student == null)
            {
                // رجع الاصل 
                return Ok(new
                {
                    message = "errors successful"
                
                });
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, student.Password);

            if (!isPasswordValid)
            {
                return Unauthorized(new { error = "Invalid email or password" });
            }

            return Ok(new
            {
                message = "Login successful",
                student = new
                {
                    student.Name,
                    student.Email
                }
            });
        }
    }
}
