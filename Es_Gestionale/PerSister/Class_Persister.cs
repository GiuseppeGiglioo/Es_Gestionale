﻿using Microsoft.Data.SqlClient;
using Es_Gestionale.Costants;
using Es_Gestionale.Model;

namespace Es_Gestionale.PerSister
{
    public class Class_Persister
    {
        public bool AddStudent(Class student)
        {
            var sql = @"
                        INSERT INTO [dbo].[Class]
                                   ([IdStudent]
                                   ,[IdLesson])
                             VALUES
                                   (@IdStudent
                                   ,@IdLesson)";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdStudent", student.IdStudent);
            command.Parameters.AddWithValue("@IdLesson", student.IdLesson);

            return command.ExecuteNonQuery() > 0;
        }
    }
}