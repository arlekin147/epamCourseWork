using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Xml.Linq;
using Training.Exceptions.RepositoryExceptions;
using Training.Exceptions.ConfigExceptions;
using Training.Utils;
using Microsoft.Extensions.Logging;

namespace Training.Repositories
{
    public class ScoreRepository : ITwoKeysRepository<Score>
    {
        private readonly DbProviderFactory providerFactory;
        private readonly string connectionString;
        private readonly IDbConnection connection;
        private readonly string getAllScoresByStudentIdQuery;
        private readonly string getAllScoresByLectionIdQuery;
        private readonly string getAllScoresQuery;
        private readonly string createScoreQuery;
        private readonly string deleteScoreQuery;
        private readonly string updateScoreQuery;
        private readonly string getScoreQuery;
        private readonly ILogger logger;


        public ScoreRepository(Config config/*, ILogger logger*/)
        {
            //this.providerFactory = DbProviderFactories.GetFactory(config.Factory);
            connection = new SqlConnection();// = this.providerFactory.CreateConnection();
            
            this.connectionString = config.ConnectionString;

            this.getAllScoresQuery = config.GetAllScoresQuery;
            
            this.createScoreQuery = config.CreateScoreQuery;
            
            this.deleteScoreQuery = config.DeleteCourseQuery;
            
            this.updateScoreQuery = config.UpdateScoreQuery;
            
            this.getScoreQuery = config.GetScoreQuery;

            this.getAllScoresByStudentIdQuery = config.GetAllScoresByStudentIdQuery;

            this.getAllScoresByLectionIdQuery = config.GetAllScoresByLectionIdQuery;
        }


        public void Create(Score score)
        {
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = this.createScoreQuery;
                    command.Connection = this.connection;
                    var param = command.CreateParameter();
                    param.ParameterName = "@LectionID";
                    param.Value = score.LectionId;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@StudentID";
                    param.Value = score.StudentId;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@isVisit";
                    param.Value = score.IsVisit;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@isHomework";
                    param.Value = score.IsHomework;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@Mark";
                    param.Value = score.Mark;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void Delete(int lectionId, int studentId)
        {
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = this.deleteScoreQuery;
                    command.Connection = this.connection;

                    var param = command.CreateParameter();
                    param.ParameterName = "@lectionId";
                    param.Value = lectionId;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@studentId";
                    param.Value = studentId;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Score Get(int LectionID, int studentID)
        {
            Score score;
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {

                    var list = connection.Query<Score>(this.getScoreQuery
                        .ChangeSubstring("@LectionID", LectionID.ToString())
                        .ChangeSubstring("@StudentID", studentID.ToString())).ToList<Score>();
                    if (list.Count == 0) throw new CourseDoesNotExistException("Попытка получения курса" +
                         " с несуществующим id");
                    score = list[0];
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return score;
        }

        public IEnumerable<Score> GetAllByFirstId(int StudentId)
        {
            List<Score> courses;
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    var query = this.getAllScoresByStudentIdQuery.ChangeSubstring("@StudentID", StudentId.ToString());
                    courses = connection.Query<Score>(query).ToList<Score>();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return courses;
        }

        public IEnumerable<Score> GetAllBySecondId(int LectionId)
        {
            List<Score> courses;
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    var query = this.getAllScoresByLectionIdQuery.ChangeSubstring("@LectionID", LectionId.ToString());
                    courses = connection.Query<Score>(query).ToList<Score>();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return courses;
        }

        public IEnumerable<Score> GetList()
        {
            List<Score> courses;
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    courses = connection.Query<Score>(this.getAllScoresQuery).ToList<Score>();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return courses;
        }

        public void Update(Score course)
        {
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    var command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = this.updateScoreQuery;
                    var param = command.CreateParameter();
                    param.ParameterName = "@LectionID";
                    param.Value = course.LectionId;
                    command.Parameters.Add(param);
                    
                    param = command.CreateParameter();
                    param.ParameterName = "@StudentID";
                    param.Value = course.StudentId;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@IsHomeWork";
                    param.Value = course.IsHomework;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@IsVisit";
                    param.Value = course.IsVisit;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@Mark";
                    param.Value = course.Mark;
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
