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
    public class LectionRepository : IRepository<Lection>
    {
        private readonly DbProviderFactory providerFactory;
        private readonly string connectionString;
        private readonly IDbConnection connection;
        private readonly string getAllLectionsQuery;
        private readonly string createLectionQuery;
        private readonly string deleteLectionQuery;
        private readonly string updateLectionQuery;
        private readonly string getLectionQuery;
        private readonly ILogger logger;


        public LectionRepository(Config config/*, ILogger logger*/)
        {
            //this.providerFactory = DbProviderFactories.GetFactory(config.Factory);
            this.connection = new SqlConnection();//= this.providerFactory.CreateConnection();
            
            this.connectionString = config.ConnectionString;
            
            this.getAllLectionsQuery = config.GetAllLectionsQuery;
            
            this.createLectionQuery = config.CreateLectionQuery;
            
            this.deleteLectionQuery = config.DeleteLectionQuery;
            
            this.updateLectionQuery = config.UpdateLectionQuery;
            
            this.getLectionQuery = config.GetLectionQuery;
        }


        public void Create(Lection lection)
        {
            try
            {
                Console.WriteLine("Creating of " + lection);
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = this.createLectionQuery;
                    command.Connection = this.connection;
                    var param = command.CreateParameter();
                    param.ParameterName = "@LectionID";
                    param.Value = lection.ID;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@LectionName";
                    param.Value = lection.Name;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@LectorID";
                    param.Value = lection.LectorID;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@Date";
                    param.Value = lection.Date;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@CourseID";
                    param.Value = lection.CourseId;
                    command.Parameters.Add(param);

                    try
                    {
                        command.ExecuteNonQuery();
                    }catch(SqlException e)
                    {
                        throw new LectionHasAlreadyExistedException($"Лекция с id = {lection.ID} уже существует ", e);
                    }
                    Console.WriteLine("Creating of " + lection + " DONE !");

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
                    command.CommandText = this.deleteLectionQuery;
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
        public Lection Get(int id)
        {
            Lection lection;
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    var list = connection.Query<Lection>(getLectionQuery
                        .ChangeSubstring("@ID", id.ToString())).ToList<Lection>();
                    if (list.Count == 0) throw new LectionDoesNotExistException("Попытка получения лекции" +
                         " с несуществующим id");
                    lection = list[0];
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return lection;
        }

        public IEnumerable<Lection> GetList()
        {
            List<Lection> lections;
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    lections = connection.Query<Lection>(this.getAllLectionsQuery).ToList<Lection>();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return lections;
        }
        

        public void Update(Lection lection)
        {
            try
            {
                this.connection.ConnectionString = this.connectionString;
                using (this.connection)
                {
                    var command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = this.updateLectionQuery;

                    var param = command.CreateParameter();
                    param.ParameterName = "@ID";
                    param.Value = lection.ID;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@LectionName";
                    param.Value = lection.Name;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@LectorID";
                    param.Value = lection.LectorID;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@Date";
                    param.Value = lection.Date;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@CourseID";
                    param.Value = lection.CourseId;
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
