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
    public interface ICategoryReponsitory
    {
        List<Category> GetAll();
    }
    public class CategoryReponsitory: ICategoryReponsitory
    {

        private readonly IConfiguration _configuration;
        public CategoryReponsitory(IConfiguration configuration)
        {
            _configuration = configuration;
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
