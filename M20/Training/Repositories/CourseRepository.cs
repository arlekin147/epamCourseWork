using System.Collections.Generic;
using System.Linq;
using Training.Models;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Data.Common;
using Training.Exceptions.RepositoryExceptions;
using Training.Utils;
using Microsoft.Extensions.Logging;

namespace Training.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly DbProviderFactory providerFactory;
        private readonly string connectionString;
        private readonly IDbConnection connection;
        private readonly string getAllCoursesQuery;
        private readonly string createCourseQuery;
        private readonly string deleteCourseQuery;
        private readonly string updateCourseQuery;
        private readonly string getCourseQuery;
        private readonly ILogger logger;


        public CourseRepository(Config config)
        {
            //this.logger = logger;
            //logger.LogDebug("ogo");
            
            //this.providerFactory = DbProviderFactories.GetFactory(config.Factory);
            connection = new SqlConnection(); //this.providerFactory.CreateConnection();

            
            this.connectionString = config.ConnectionString;
            
            this.getAllCoursesQuery = config.GetAllCoursesQuery;
             
            this.createCourseQuery = config.CreateCourseQuery; 

            this.deleteCourseQuery = config.DeleteCourseQuery;
            
            this.updateCourseQuery = config.UpdateCourseQuery;
            
            this.getCourseQuery = config.GetCourseQuery;
        }

    
        public void Create(Course course)
        {
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = this.createCourseQuery;
                    command.Connection = this.connection;
                    var param = command.CreateParameter();
                    param.ParameterName = "@CourseID";
                    param.Value = course.ID;
                    command.Parameters.Add(param);
                    param = command.CreateParameter();
                    param.ParameterName = "@CourseName";
                    param.Value = course.Name;
                    command.Parameters.Add(param);
                    try
                    {
                        command.ExecuteNonQuery();
                    }catch(SqlException e)
                    {
                        throw new CourseHasAlreadyExistedException($"Курс с id = {course.ID} уже существует", e);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = this.deleteCourseQuery;
                    command.Connection = this.connection;
                    var param = command.CreateParameter();
                    param.ParameterName = "@ID";
                    param.Value = id;
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        

        public Course Get(int id)
        {
            Course course;
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {

                    var list = connection.Query<Course>(getCourseQuery
                        .ChangeSubstring("@ID", id.ToString())).ToList<Course>();
                    if (list.Count == 0) throw new CourseDoesNotExistException($"Курс с id = {id} не существует");
                    course = list[0];
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return course;
        }

        public IEnumerable<Course> GetList()
        {
            List<Course> courses;
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    courses = connection.Query<Course>(this.getAllCoursesQuery).ToList<Course>();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return courses;
        }

        public void Update(Course course)
        {
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    var command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = this.updateCourseQuery;

                    var param = command.CreateParameter();
                    param.ParameterName = "@ID";
                    param.Value = course.ID;
                    command.Parameters.Add(param);
                    param = command.CreateParameter();
                    param.ParameterName = "@CourseName";
                    param.Value = course.Name;
                    command.Parameters.Add(param);
                    try {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        throw new CourseHasAlreadyExistedException($"Курс с id = {course.ID} уже существует");
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
