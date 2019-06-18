using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Training.Exceptions.RepositoryExceptions;
using Training.Models;
using System.Data;

namespace Training.Repositories
{
    public class LectorRepository : IRepository<Lector>
    {
        private string connectionString = "Data Source=localhost; Integrated Security=SSPI;" +
            " Initial Catalog=TestDataBase;";

        public IEnumerable<Lector> GetList()
        {
            List<Lector> lectors;
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    lectors = connection.Query<Lector>("SELECT * FROM lector").ToList();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return lectors;
        }

        public Lector Get(int id)
        {
            Lector lector;
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var list = connection.Query<Lector>($"SELECT * FROM lector WHERE ID = {id}").ToList();
                    if (list.Count != 1) throw new LectorDoesNotExistException($"Не существует лектора с" +
                        $" id = {id}");
                    lector = list[0];
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return lector;
        }

        public void Create(Lector lector)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Query("INSERT INTO lector (ID, Name, Surname, Email)" +
                            $" VALUES ('{lector.ID}', '{lector.Name}'," +
                            $" '{lector.Surname}', '{lector.Email}')");
                    }
                    catch (SqlException)
                    {
                        throw new LectorHasAlreadyExistedException("Попытка создать лектора с уже" +
                            $" существующим ID. Лектор: {lector}");
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void Update(Lector lector)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query("UPDATE lector SET " +
                        $"Name = '{lector.Name}', " +
                        $"Surname = '{lector.Surname}', " +
                        $"Email = '{lector.Email}' " +
                        $"WHERE ID = {lector.ID} ");
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
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Query($"DELETE FROM lector WHERE ID = {id}");
                    }
                    catch (SqlException)
                    {
                        throw new LectorDoesNotExistException($"Попытка удалить несуществующего," +
                            $" в базе данных, лектора с id = {id}");
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

