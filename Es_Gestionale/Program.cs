using Es_Gestionale;
using Es_Gestionale.PerSister;


var ConnectionString = "Server=ACADEMYNETUD07\\SQLEXPRESS;Database=Es_Gestionale;Trusted_Connection=True;";

var person_Persister= new Person_Persister(ConnectionString);
var stundent_Persister=new Student_Persister(ConnectionString);
var teacher_Persister=new Teacher_Persister(ConnectionString);
var subject_Persister=new Subject_Persister(ConnectionString);
var exam_Persister=new Exam_Persister(ConnectionString);



var person=new Person()
{
    Id =234,
    Name="Karim",
    Surname="Benz",
    Birthday=new DateTime(1988, 4, 22),
    Gender="Male",
    Address="Santago Bernabeu"

};
var IdPerson = person_Persister.AddPerson(person);


var student = new Student() {

    Id=person.Id,
    Name=person.Name,
    Birthday=person.Birthday,
    Gender=person.Gender,
    Address=person.Address,
    Matricola="17751AB",
    DataIscrizione=DateTime.Now

};
var idStudent=stundent_Persister.AddStudent(student);

student.IdStudent = idStudent;


var teacher = new Teacher() {
    Id = person.Id,
    Name = person.Name,
    Birthday = person.Birthday,
    Gender = person.Gender,
    Address = person.Address,
    DataAssunzione=new DateTime(2003, 7, 9),
    Matricola="MR567",
    Subject="Analisi 1"

};
var Iteacher=teacher_Persister.AddTeacher(teacher);
teacher.IdTeacher = Iteacher;


var subject = new Subject() {
    Id = teacher.Id,
    IdSubject = 5643,
     NameSub="Analisi 1",
     Description="Matematica e Trigonometria",
     CFU=12,
     Hours=18
};

var idsubject=subject_Persister.AddSubject(subject);
subject.IdSubject = idsubject;


var exam = new Exam() {

    IdTeacher = teacher.IdTeacher,
    IdSubject = subject.IdSubject,
    Date = new DateTime(1996, 10, 25)

};
var idexam = exam_Persister.AddExam(exam);
exam.IdExam=idexam;

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"persona: {Name}, {Surname}, residenza { Address}, nata il {Birthday}, genere: {Gender} ");

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"studente{Name}, {Surname},residenza { Address},nata il {Birthday},genere {Gender},matricola {Matricola},inizio corso di laurea {DataImmatricolazione} ");

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"teacher: {Name}, {Surname}, id: { Id}, genere: {Gender},matricola {Matricola},nata il {Birthday},materia {Subject}, inizio lavoro {DataAssunzione}");

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"subject: {Name},id { Id}, durata {Hours}, descrizione {Description},crediti formativi {CFU}");

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"exam del prof {IdTeacher}, materia {IdSubject}, giorno {Date}");

Console.ReadLine();


