﻿

namespace Es_Gestionale
{
 public class Teacher: Person
    {
        public int IdTecher { get; set; }
        public int IdPerson { get; set; }

        public string Matricola { get; set; }
        public DateTime DataAssunzione { get; set; }
    }
}