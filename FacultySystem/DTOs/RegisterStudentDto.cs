using System.ComponentModel.DataAnnotations;

namespace FacultySystem.DTOs
{
    public class RegisterStudentDto
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        public bool Gender { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string NationalId { get; set; }

        public int Year { get; set; }
    }
    public class RegisterDoctorDto
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        public bool Gender { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string NationalId { get; set; }

    }
}
