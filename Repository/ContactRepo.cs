using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactRepo : IContactRepo
    {
        private readonly RepoSetting _repoSetting;

        public ContactRepo(IOptions<RepoSetting> options)
        {
            _repoSetting = options.Value;
        }

        public async Task<Contact?> Get(int id)
        {
            Contact? contact = null;
            using (SqlConnection connection = new SqlConnection(_repoSetting.ConnectionString))
            {
                await connection.OpenAsync();

                string sql = "dbo.GetContact";
                var command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter
                {
                    ParameterName = "@Id", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Int, //Data Type of Parameter
                    Value = id, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };

                command.Parameters.Add(param1);

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        contact = new Contact
                        {
                            FirstName = Convert.ToString(dataReader["FirstName"]),
                            LastName = Convert.ToString(dataReader["LastName"]),
                            Email = Convert.ToString(dataReader["Email"]),
                            Company = Convert.ToString(dataReader["Company"]),
                            Title = Convert.ToString(dataReader["Title"]),
                        };

                    }

                }

                connection.Close();
            }

            return contact;
        }
        public async IAsyncEnumerable<Contact?> Get()
        {
            using (SqlConnection connection = new SqlConnection(_repoSetting.ConnectionString))
            {
                await connection.OpenAsync();

                string sql = "dbo.GetContacts";
                var command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        yield return new Contact
                        {
                            FirstName = Convert.ToString(dataReader["FirstName"]),
                            LastName = Convert.ToString(dataReader["LastName"]),
                            Email = Convert.ToString(dataReader["Email"]),
                            Company = Convert.ToString(dataReader["Company"]),
                            Title = Convert.ToString(dataReader["Title"]),
                        };

                    }

                }

                connection.Close();
            }


        }
    }
}
