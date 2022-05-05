

using System.Data.SqlClient;

namespace Es_Gestionale.PerSister
{
   public class Exam_Persister
    {
        private readonly string ConnectionString;
        public Exam_Persister(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public int AddExam(Exam exam)
        {
            var sql = @"
                        INSERT INTO [dbo].[Teacher]
                                   ([IdExam]
                                   ,[IdStudent])
                             VALUES
                                   (@IdExam
                                   ,@IdStudent);
SELECT @@IDENTITY AS 'idendtity';";

            using var connection = new SqlConnection(MyConstant.ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", exam.IdExam);
            command.Parameters.AddWithValue("@Date", exam.Date);
            return Convert.ToInt32(command.ExecuteNonQuery());
        }
    }
}
