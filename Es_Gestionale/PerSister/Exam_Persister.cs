using Microsoft.Data.SqlClient;
using Es_Gestionale.Costants;
using Es_Gestionale.Model;

namespace Es_Gestionale.PerSister
{
   public class Exam_Persister
    {
        public bool AddExamDetail(ExamDetail examDetail)
        {
            var sql = @"
                        INSERT INTO [dbo].[Teacher]
                                   ([IdExam]
                                   ,[IdStudent])
                             VALUES
                                   (@IdExam
                                   ,@IdStudent)";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", examDetail.IdExam);
            command.Parameters.AddWithValue("@Matricola", examDetail.IdStudent);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
