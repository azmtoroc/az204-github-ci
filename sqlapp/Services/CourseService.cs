using sqlapp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace sqlapp.Services
{
    public class CourseService
    {
        private static string db_source = "az204-sqldatabase-sql.database.windows.net";
        private static string db_user = "mtoroc";
        private static string db_password = "Toroku1985..";
        private static string db_database = "az204-sqldatabase-sqldb";

        private SqlConnection GetConnection(string _connection_string)
        {
            //var builder = new SqlConnectionStringBuilder();
            //builder.DataSource = db_source;
            //builder.UserID = db_user;
            //builder.Password = db_password;
            //builder.InitialCatalog = db_database;

            return new SqlConnection(_connection_string);
        }

        public IEnumerable<Course> GetCourses(string _connection_string)
        {
            List<Course> _lst = new List<Course>();
            string _statement = "SELECT * FROM Course;";
            SqlConnection _connection = GetConnection(_connection_string);
            _connection.Open();
            SqlCommand _sqlCommand = new SqlCommand(_statement, _connection);

            using (SqlDataReader _reader = _sqlCommand.ExecuteReader())
            {

                while (_reader.Read())
                {

                    Course _course = new Course()
                    {
                        CourseID = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };

                    _lst.Add(_course);
                }
            }

            _connection.Close();

            return _lst;
        }
    }
}
