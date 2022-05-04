using Microsoft.Data.SqlClient;
using Es_Gestionale.Costants;
using Es_Gestionale.Model;

namespace Es_Gestionale.PerSister
{
    public class Person_Persister
    {
        public bool AddPerson(Person person)
        {
            var sql = @"
                        INSERT INTO [dbo].[Person]
                                   ([Name],
                                   [Surname],
                                   [BirthDay],
                                   [Gender],
                                   [Address])
                             VALUES
                                   (@Name,
                                    @Surname,
                                    @BirthDay,
                                    @Gender,
                                    @Address)";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@SurName", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.BirthDay);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Adress", person.Address);


            return command.ExecuteNonQuery() > 0;
        }
    }
}
