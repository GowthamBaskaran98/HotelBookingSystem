using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace HotelBooking
{
    class UserRepository
    {
        public UserRepository(User data)
        {
            SqlConnection sqlConnection = Connector.GetDBConnection();
            sqlConnection.Open();
            string sql = "REGISTRATION";
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@userId";
                parameter.Value = data.userId;
                parameter.SqlDbType = SqlDbType.Char;
                sqlCommand.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@mobileNumber";
                parameter.Value = data.mobileNumber;
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@password";
                parameter.Value = data.password;
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@userType";
                parameter.Value = data.userType;
                parameter.SqlDbType = SqlDbType.Char;
                sqlCommand.Parameters.Add(parameter);
                int retRows = sqlCommand.ExecuteNonQuery();
                if (retRows >= 1)
                {
                    Console.WriteLine("Registered Successfully");
                }
                else
                {
                    Console.WriteLine("There is a problem in connecting, Try again later");
                }

            }
        }
    }
}
