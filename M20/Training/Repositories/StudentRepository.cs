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
    public class StudentRepository : IRepository<Student>
    {
        private readonly string connectionString = "Data Source=localhost; Integrated Security=SSPI; Initial Catalog=TestDataBase;";

        public IEnumerable<Student> GetList()
        {
            List<Student> students;
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    students = connection.Query<Student>("SELECT * FROM student").ToList();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return students;
        }

        public Student Get(int id)
        {
            Student st;
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var list = connection.Query<Student>($"SELECT * FROM student WHERE ID = {id}").ToList();
                    if (list.Count != 1) throw new StudentDoesNotExistsException($"Не существует студента с id = {id}");
                    st = list[0];
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return st;
        }

        public void Create(Student st)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Query("INSERT INTO student (ID, Name, Surname, Email, PhoneNumber)" +
                            $" VALUES ('{st.ID}', '{st.Name}', '{st.Surname}', '{st.Email}', '{st.PhoneNumber}')");
                    }
                    catch (SqlException)
                    {
                        throw new StudentHasAlreadyExistedException("Попытка вставить студента с уже существующим ID." +
                            $" Студент: {st}");
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void Update(Student st)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query("UPDATE student SET " +
                        $"Name = '{st.Name}', " +
                        $"Surname = '{st.Surname}', " +
                        $"Email = '{st.Email}'," +
                        $"PhoneNumber = '{st.PhoneNumber}'" +
                        $"WHERE ID = {st.ID} ");
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
                    connection.Query($"DELETE FROM student WHERE ID = {id}");
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

    }
}
