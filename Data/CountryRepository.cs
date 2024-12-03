using Microsoft.Data.SqlClient;
using System.Data;
using SampleApi.Models;
using Microsoft.Extensions.Configuration;
namespace SampleApi.Data
{
    public class CountryRepository
    {
        private readonly string _connectionString;
        public CountryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultString");
        }

        //This conutryrepository use for database connection 
        #region SelectAllcountries And Call this in Contrycontroller 

        public IEnumerable<CountryModel> SelectAllCountries()
        {
            var countries = new List<CountryModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_LOC_Country_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(new CountryModel
                    {
                        CountryId = Convert.ToInt32(reader["CountryId"]),
                        CountryName = reader["CountryName"].ToString(),
                        CountryCode = reader["CountryCode"].ToString(),
                    });
                }
                return countries;

            }
        }
        #endregion
    }
}
