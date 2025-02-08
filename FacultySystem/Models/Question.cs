using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace FacultySystem.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // image

        // file

        public byte Type { get; set; }

        public string CorrectAns { get; set; }

        public int Grade { get; set; }


        //relationShips

        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        public ICollection<QuestionAns> QuestionAnss { get; set; }
        public ICollection<Choice> Choices { get; set; }

    }
    public class Choice
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public DateTime AddedOn { get; set; }
        public string choice { get; set; }
    }
}
