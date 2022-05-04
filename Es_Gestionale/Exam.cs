

namespace Es_Gestionale
{
   public class Exam: Subject
    {
        public int IdExam { get; set; }
        public int IdTeacher { get; set; }
        public DateTime Date { get; set; }
        public int IdSubject { get; set; }
    }
}
