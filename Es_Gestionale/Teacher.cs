

namespace Es_Gestionale
{
 public class Teacher: Person
    {
        public int IdTeacher { get; set; }

        public string Matricola { get; set; }
        public string Subject { get; set; }
        public DateTime DataAssunzione { get; set; }
    }
}
