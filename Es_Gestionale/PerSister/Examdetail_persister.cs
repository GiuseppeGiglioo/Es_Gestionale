using System.Data.SqlClient;


namespace Es_Gestionale.PerSister
{
    public class Examdetail_persister
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

            using var connection = new SqlConnection(MyConstant.ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", examDetail.IdExam);
            command.Parameters.AddWithValue("@Matricola", examDetail.IdStudent);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
