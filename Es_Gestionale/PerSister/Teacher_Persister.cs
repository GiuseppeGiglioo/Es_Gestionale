﻿using Microsoft.Data.SqlClient;
using Es_Gestionale.Costants;
using Es_Gestionale.Model;

namespace Es_Gestionale.PerSister
{
    public class Teacher_Persister
    {
        public bool AddTeacher(Teacher teacher)
        {
            var sql = @"
                        INSERT INTO [dbo].[Teacher]
                                   ([IdPerson]
                                   ,[Matricola]
                                   ,[DataAssunzione])
                             VALUES
                                   (@IdPerson
                                   ,@Matricola
                                   ,@DataAssunzione)";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", teacher.Id);
            command.Parameters.AddWithValue("@Matricola", teacher.Matricola);
            command.Parameters.AddWithValue("@DataAssunzione", teacher.DataAssunzione);

            return command.ExecuteNonQuery() > 0;
        }
    }
}