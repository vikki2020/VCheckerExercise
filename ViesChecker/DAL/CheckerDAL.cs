using ViesChecker.Model;  
using Microsoft.Extensions.Configuration;  
using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.SqlClient;  
namespace ViesChecker.DAL
{
    public class CheckerDAL
    {
        //fields
        private string _connectionString;

        //ctors
        public CheckerDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        //methods
        public List<CheckerModel> GetList()
        {
            var listCheckerModel = new List<CheckerModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ViesFullData_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listCheckerModel.Add(new CheckerModel
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Country = rdr[1].ToString(),
                            City = rdr[2].ToString(),
                            Address = rdr[3].ToString(),
                            Name = rdr[4].ToString(),
                            CountryCode = rdr[5].ToString(),
                            VatNumber = rdr[6].ToString(),
                            RequestDate = ((DateTime)rdr[7]),
                            IsValid = Convert.ToBoolean(rdr[8])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listCheckerModel;
        }
    }
}
