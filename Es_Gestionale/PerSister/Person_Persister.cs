

using System.Data.SqlClient;

namespace Es_Gestionale.PerSister
{
    public class Person_Persister
    {
        private readonly string ConnectionString;
        public Person_Persister(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public int AddPerson(Person person)
        {
            var sql = @"
                        INSERT INTO [dbo].[Person]
                                   ([Name],
                                   [Surname],
                                   [Birthday],
                                   [Gender],
                                   [Address])
                             VALUES
                                   (@Name,
                                    @Surname,
                                    @Birthday,
                                    @Gender,
                                    @Address);
                            SELECT @@IDENTITY AS 'idendtity'; ";

            using var connection = new SqlConnection(MyConstant.ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@SurName", person.Surname);
            command.Parameters.AddWithValue("@Birthday", person.Birthday);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Adress", person.Address);
            return Convert.ToInt32(command.ExecuteScalar());

            
        }
    }
}
