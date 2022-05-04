
using Es_Gestionale.Costante;
using System.Data.SqlClient;

namespace Es_Gestionale.PerSister
{
    public class Lesson_Persister
    {
        public bool AddLesson(Lessons lesson)
        {
            var sql = @"
                        INSERT INTO [dbo].[Lesson]
                                   ([IdTeacher]
                                   ,[IdSubject])
                             VALUES
                                   (@IdTeacher
                                   ,@IdSubject)";

            using var connection = new SqlConnection(constants.Connection_String);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdTeacher", lesson.IdTeacher);
            command.Parameters.AddWithValue("@Matricola", lesson.IdSubject);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
