using System.ComponentModel.DataAnnotations;

namespace FacultySystem.Models
{
    public class Staff
    {
        public Staff(string Email, string Name, bool Gender, string PhoneNumber,
           string NationalId, string Password)
        {
            this.Email = Email;
            this.Name = Name;
            this.Gender = Gender;
            this.PhoneNumber = PhoneNumber;
            this.NationalId = NationalId;
            this.Password = Password;
        }

        [Key]
        public string Email { get; set; }
        public string Name { get; set; }

        public bool Gender { get; set; }
        
        public string PhoneNumber { get; set; }

        public string NationalId { get; set; }

        public string Password { get; set; }

        // image



        // relationShips
        public ICollection<News>News  { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Registeration> Registerations { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
    public class Registeration
    {
        public int StaffEmail { get; set; }
        public string SubjectDepartment { get; set; }
        public string SubjectLevel { get; set; }

        public Staff Staff { get; set; }
        public Subject Subject { get; set; }
    }
    public class Material
    {
        public int StaffEmail { get; set; }
        public string SubjectDepartment { get; set; }
        public string SubjectLevel { get; set; }
        public DateTime UploadedAt { get; set; }
        // file

        public Staff Staff { get; set; }
        public Subject Subject { get; set; }
    }

    public class Post
    {
        public int StaffEmail { get; set; }
        public string SubjectDepartment { get; set; }
        public string SubjectLevel { get; set; }
        public string Content { get; set; }
        public DateTime UploadedAt { get; set; }
        // photo

        // relationships
        public Staff Staff { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
    public class Comment
    {
        public int PostStaffEmail { get; set; }
        public string PostSubjectDepartment { get; set; }
        public string PostSubjectLevel { get; set; }
        public string Content { get; set; }
        public string CommenterEmail { get; set; }

        // relationships
        public Post Post { get; set; }
    }
}
