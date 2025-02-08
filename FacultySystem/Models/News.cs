using System.Reflection.Metadata.Ecma335;

namespace FacultySystem.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Content { get; set; }

        // comment
        // image

        //foreign key
        public int StaffEmail { get; set; }

        public Staff Staff { get; set; }

    }
}
