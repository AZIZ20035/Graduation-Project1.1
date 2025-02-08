using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FacultySystem.Configurations;
using FacultySystem.DTOs;
using FacultySystem.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Azure.Core;


namespace FacultySystem.Controllers
{
    [ApiController]

    [Route("[controller]")]

    //here
    public class User : ControllerBase
    {
        private readonly AppDbContext _context;
        public User(AppDbContext context)
        {
            _context = context;
        }

        // here

        [HttpPost("Exists")]

        public bool exist(string email)
        {
            return _context.Students.Any(s => s.Email == email) ||
                _context.Staffs.Any(s => s.Email == email);
        }

        //here

        [HttpPost("RegisterStudent")]

        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentDto request)
        {
            if (exist(request.Email))
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

            return Created("", new { message = "Student registered successfully" });
        }

        //here
        [HttpPost("RegisterDoctor")]

        //here
        public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorDto request)
        {

            //here

            if (exist(request.Email))
            {
                return BadRequest(new { error = "Email already exists" });
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            Staff staff = new Staff
            {
                Email = request.Email,
                Name = request.FullName,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                NationalId = request.NationalId,
                Password = hashedPassword
            };

            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return Created("", new { message = "User registered successfully" });
        }




        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == request.Email);

            if (student != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, student.Password);

                if (!isPasswordValid)
                {
                    return Unauthorized(new { error = "Invalid email or password" });
                }

                return Ok(new
                {
                    message = "Student Logged successfully",
                    student = new
                    {
                        student.Name,
                        student.Email
                    }
                });
            }
            var doctor = await _context.Staffs.FirstOrDefaultAsync(s => s.Email == request.Email);
            if (doctor != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, doctor.Password);

                if (!isPasswordValid)
                {
                    return Unauthorized(new { error = "Invalid email or password" });
                }

                return Ok(new
                {
                    message = "Doctor Logged successfully",
                    doctor = new
                    {
                        doctor.Name,
                        doctor.Email
                    }
                });
            }
            return BadRequest(new { error = "User not found" });

        }
    }
}
