using Microsoft.Data.SqlClient;
using SampleApi.Models;
using System.Data;

namespace SampleApi.Data
{
    public class StateRepository
    {
        private string _connectionString;
        public StateRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultString");
        }
        //This staterepository use for database connection 
        #region SelectAllstateAnd Call this in statecontroller 

        public IEnumerable<StateModel> SelectAllStates()
        {
            var states = new List<StateModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_LOC_State_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    states.Add(new StateModel
                    {
                        StateId = Convert.ToInt32(reader["StateId"]),
                        CountryId= Convert.ToInt32(reader["CountryId"]),
                        CountryName = reader["CountryId"].ToString(),

                        StateName = reader["StateId"].ToString(),
                        StateCode = reader["StateId"].ToString(),

                    });
                }
                return states;
            }
        }
        #endregion
    }
}
