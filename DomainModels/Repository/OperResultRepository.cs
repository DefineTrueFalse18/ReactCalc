using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class OperResultRepository : IOperResultRepository
    {
        public OperationResult Create()
        {
            throw new NotImplementedException();
        }

        public void Delete(OperationResult operResult)
        {
            throw new NotImplementedException();
        }

        public OperationResult Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperationResult> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rustam\Desktop\Work(Elewise)\ReactCalc\DomainModels\AppData\reactcalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Author, Operation FROM OperationResult;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var author = reader.GetString(1);
                        var operation = reader.GetString(2);

                        yield return new OperationResult()
                        {
                            Id = id,
                            Author = author,
                            Operation = operation
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

        public void Update(OperationResult operResult)
        {
            throw new NotImplementedException();
        }
    }
}
