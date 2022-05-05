

using System.Data.SqlClient;

namespace Es_Gestionale.PerSister
{
    public class Subject_Persister
    {
        private readonly string ConnectionString;
        public Subject_Persister(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public int AddSubject(Subject subject)
        {
            var sql = @"
                        INSERT INTO [dbo].[Subject]
                                   ([Name]
                                   ,[Description]
                                   ,[Credits]
                                   ,[Hours])
                             VALUES
                                   (@Name
                                   ,@Description
                                   ,@Credits
                                   ,@Hours);
SELECT @@IDENTITY AS 'idendtity';";


            using var connection = new SqlConnection(MyConstant.ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", subject.Name);
            command.Parameters.AddWithValue("@Description", subject.Description);
            command.Parameters.AddWithValue("@CFU", subject.CFU);
            command.Parameters.AddWithValue("@Hours", subject.Hours);

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
