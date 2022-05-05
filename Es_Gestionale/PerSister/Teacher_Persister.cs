

using System.Data.SqlClient;

namespace Es_Gestionale.PerSister
{
    public class Teacher_Persister
    {
        private readonly string ConnectionString;
        public Teacher_Persister(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public int AddTeacher(Teacher teacher)
        {
            var sql = @"
                        INSERT INTO [dbo].[Teacher]
                                   ([IdPerson]
                                   ,[Matricola]
                                   ,[DataAssunzione])
                             VALUES
                                   (@IdPerson
                                   ,@Matricola
                                   ,@DataAssunzione);
SELECT @@IDENTITY AS 'idendtity';";

            using var connection = new SqlConnection(MyConstant.ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", teacher.Id);
            command.Parameters.AddWithValue("@Matricola", teacher.Matricola);
            command.Parameters.AddWithValue("@DataAssunzione", teacher.DataAssunzione);

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
