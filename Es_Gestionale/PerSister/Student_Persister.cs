

using System.Data.SqlClient;

namespace Es_Gestionale.PerSister
{
   public class Student_Persister
    {
        private readonly string ConnectionString;
        public Student_Persister(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public int AddStudent(Student student)
        {
            var sql = @"
                        INSERT INTO [dbo].[Student]
                                   ([IdPerson]
                                   ,[Matricola]
                                   ,[DataIscrizione])
                             VALUES
                                   (@IdPerson
                                   ,@Matricola
                                   ,@DataIscrizione);
SELECT @@IDENTITY AS 'idendtity'; ";

            using var connection = new SqlConnection(MyConstant.ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", student.Id);
            command.Parameters.AddWithValue("@Matricola", student.Matricola);
            command.Parameters.AddWithValue("@DataIscrizione", student.DataIscrizione);
            return Convert.ToInt32(command.ExecuteNonQuery());

            

        }
    }
}
