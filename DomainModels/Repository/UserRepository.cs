using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public class UserRepository : IUserRepository
    {
        public Models.User Create()
        {
            throw new NotImplementedException();
        }

        public Models.User Get(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Models.User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.User> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rustam\Desktop\Work(Elewise)\ReactCalc\DomainModels\AppData\reactcalc.mdf;Integrated Security=True"))
            {                                           
                SqlCommand command = new SqlCommand("SELECT Id, FIO, Login FROM Users;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var fio = reader.GetString(1);
                        var login = reader.GetString(2);

                        yield return new User()
                        {
                            Id = id,
                            FIO = fio,
                            Login = login
                        };
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }

        public IEnumerable<Models.User> GetUserInfo(long id_user)
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rustam\Desktop\Work(Elewise)\ReactCalc\DomainModels\AppData\reactcalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, FIO, Login, Password FROM Users WHERE Id=" + id_user + ";", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var fio = reader.GetString(1);
                        var login = reader.GetString(2);
                        var password = reader.GetString(3);

                        yield return new User()
                        {
                            Id = id,
                            FIO = fio,
                            Login = login,
                            Password = password
                        };
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }
    }
}
