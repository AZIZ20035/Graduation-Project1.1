using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace FacultySystem.Models
{
    public class Student
    {
        public Student () 
        { 

        }
        public Student(string Email, string Name, bool Gender, string PhoneNumber,
            string NationalId, int Year, string Password, int DepartmentId)
        {
            this.Email = Email;
            this.Name = Name;
            this.Gender = Gender;
            this.PhoneNumber = PhoneNumber;
            this.NationalId = NationalId;
            this.Year = Year;
            this.Password = Password;
            this.DepartmentId = DepartmentId;
        }

       [Key]
        public string Email { get; set; }
        public string Name { get; set; }

        public bool Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string NationalId { get; set; }
       
        public int Year { get; set; }

        public string Password { get; set; }

        // image
        // relationShips
        // foreign key
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<QuestionAns> QuestionAnss { get; set; }

        public ICollection<AssignmentAns> AssignmentAnss { get; set; }
      
    }
    public class QuestionAns
    {
        public int StudentEmail { get; set; }
        public int QuestionId { get; set; }

        public Student Student { get; set; }
        public Question Question { get; set; }

        public string StudentAns { get; set; }
    }

    public class AssignmentAns
    {
        public int StudentEmail { get; set; }
        public int QuestionId { get; set; }

        public Student Student { get; set; }
        public Question Question { get; set; }

        //file

    }
}
