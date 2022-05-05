

using System.Data.SqlClient;

namespace Es_Gestionale.Retriever
{
    public class Class_Retriever
    {
        public Class? GetClassRoom(int IdClass)
        {

            var sql = @"
                    SELECT [Id]
                          ,[IdStudent]
                          ,[IdLesson]
                      FROM [dbo].[Class]
                        where Id =@IdClass";


            using var connection = new SqlConnection(MyConstant.ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdClass", IdClass);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Class
                {
                    IdClass = Convert.ToInt32(reader["Id"]),
                    IdLesson = Convert.ToInt32(reader["IdLesson"]),
                    IdStudent = Convert.ToInt32(reader["IdStudent"]),
                };
            }
            return null;

        }
    }
}
