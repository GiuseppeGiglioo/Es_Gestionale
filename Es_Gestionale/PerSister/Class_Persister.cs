

using System.Data.SqlClient;

namespace Es_Gestionale.PerSister
{
    public class Class_Persister
    {
        //public static string Connection_String = @"Server=ACADEMYNETUD07\SQLEXPRESS;Database=Es_Gestionale;Trusted_Connection=True;";
        public bool AddStudent(Class student)
        {
            var sql = @"
                        INSERT INTO [dbo].[Class]
                                   ([IdStudent]
                                   ,[IdLesson])
                             VALUES
                                   (@IdStudent
                                   ,@IdLesson)";

            using var connection = new SqlConnection(MyConstant.ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdStudent", student.IdStudent);
            command.Parameters.AddWithValue("@IdLesson", student.IdLesson);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
