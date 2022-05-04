﻿using Microsoft.Data.SqlClient;
using Es_Gestionale.Costante;
using Es_Gestionale.Model;

namespace Es_Gestionale.Retriever
{
    public class Class_Retriever
    {
        public IEnumerable<Class> GetClassRoom(int IdClass)
        {

            var sql = @"
                    SELECT [Id]
                          ,[IdStudent]
                          ,[IdLesson]
                      FROM [dbo].[Class]
                        where Id =@IdClass";


            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdClass", IdClass);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Class
                {
                    IdClass = Convert.ToInt32(reader["Id"]),
                    IdLesson = Convert.ToInt32(reader["IdLesson"]),
                    IdStudent = Convert.ToInt32(reader["IdStudent"]),
                };
            }

        }
    }
}