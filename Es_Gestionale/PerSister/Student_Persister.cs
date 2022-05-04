﻿using Microsoft.Data.SqlClient;
using Es_Gestionale.Costants;
using Es_Gestionale.Model;

namespace Es_Gestionale.PerSister
{
   public class Student_Persister
    {
        public bool AddStudent(Student student)
        {
            var sql = @"
                        INSERT INTO [dbo].[Student]
                                   ([IdPerson]
                                   ,[Matricola]
                                   ,[DataIscrizione])
                             VALUES
                                   (@IdPerson
                                   ,@Matricola
                                   ,@DataIscrizione)";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", student.Id);
            command.Parameters.AddWithValue("@Matricola", student.Matricola);
            command.Parameters.AddWithValue("@DataIscrizione", student.DataIscrizione);

            return command.ExecuteNonQuery() > 0;
        }
    }
}