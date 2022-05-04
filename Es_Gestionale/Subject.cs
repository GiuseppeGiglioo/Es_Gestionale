
namespace Es_Gestionale
{
    public class Subject: Teacher
    {
        public int IdSubject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int Hours { get; set; }
    }
}
