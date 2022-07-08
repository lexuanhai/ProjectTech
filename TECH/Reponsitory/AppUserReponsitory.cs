using Dapper;
using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface IAppUserReponsitory
    {
        int CreateUser(AppUser appUser);
    }
    public class AppUserReponsitory : IAppUserReponsitory
    {
        private readonly IConfiguration _configuration;
        public AppUserReponsitory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        public int CreateUser(AppUser appUser)
        {
            var connectionString = this.GetConnection();
            int idUser = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = con;
                        string queryString = @"INSERT INTO NguoiDung (UserName,Password,HoTen,Email) VALUES (@UserName, @Password,@HoTen,@Email);
                                               SELECT CAST(scope_identity() AS int)";
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("@UserName", appUser.UserName);
                        command.Parameters.AddWithValue("@Password", appUser.Password);
                        command.Parameters.AddWithValue("@HoTen", appUser.FullName);
                        command.Parameters.AddWithValue("@Email", appUser.Email);

                        idUser = Convert.ToInt32(command.ExecuteScalar()); 

                    }

                    return idUser;
                }
                catch
                {
                    return 0;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAll()
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    var query = @"SELECT * FROM Category WHERE IsDeleted = 0";
                    var categories = con.Query<Category>(query).ToList();

                    return categories;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }
        }       
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("MyDB").Value;
            return connection;
        }
    }
}
