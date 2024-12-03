using Microsoft.Data.SqlClient;
using SampleApi.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SampleApi.Data
{
    public class CityRepository
    {
        private readonly string _connectionString;
        public CityRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultString");
        }

        //This citypository use for database connection 
        #region SelectAllcity And Call this in citycontroller 

        public IEnumerable<CityModel> SelectAll()
        {
            var cities = new List<CityModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_LOC_City_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    cities.Add(new CityModel
                    {
                        CityId = Convert.ToInt32(reader["CityId"]),
                        StateId = Convert.ToInt32(reader["StateId"]),
                        CountryId = Convert.ToInt32(reader["CountryId"]),
                        CityName = reader["CityName"].ToString(),
                        CityCode = reader["CityCode"].ToString()

                    });

                }
                return cities;

            }
        }
        #endregion
    }
}
