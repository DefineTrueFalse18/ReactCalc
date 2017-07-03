using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;


namespace DomainModels.Repository
{
    public class OperationRepository : IOperationRepository
    {
        public Operation Create()
        {
            throw new NotImplementedException();
        }

        public void Delete(Operation oper)
        {
            throw new NotImplementedException();
        }

        public Operation Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rustam\Desktop\Work(Elewise)\ReactCalc\DomainModels\AppData\reactcalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Name, FullName FROM Operation;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var name = reader.GetString(1);
                        var fullname = reader.GetString(2);

                        yield return new Operation()
                        {
                            Id = id,
                            Name = name,
                            FullName = fullname
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

        public void Update(Operation oper)
        {
            throw new NotImplementedException();
        }
    }
}
