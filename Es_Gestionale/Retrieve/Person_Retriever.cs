using System.Data.SqlClient;

namespace Es_Gestionale.Retriever
{
    public class Person_Retriever
    {
        public IEnumerable<Person> GetPerson(string name, string surname)
        {

            var sql = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Surname]
                          ,[BirthDay]
                          ,[Gender]
                          ,[Address]
                      FROM [dbo].[Person]
                        where Surname =@surname and Name=@name";


            using var connection = new SqlConnection(MyConstant.ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Person
                {
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    Gender = reader["Gender"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    Address = reader["Address"].ToString(),
                };

            }
        }
    }
}

