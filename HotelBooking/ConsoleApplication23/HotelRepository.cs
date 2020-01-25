using System;
using System.Data;
using System.Data.SqlClient;
namespace HotelBooking
{
    class HotelRepository
    {
        public static int hotelId;
        public static int readChoice;
        public static string hotelName;
        public static string hotelAddress;
        public static short vacantRoom;
        public static short roomSize;
        public static string hotelService;
        public static int pricePerDay;
        public static short numberOfRoom;
        public static short bookedRoom = 0;
        public static int select;
        public static bool condition = true;
        public HotelRepository(Hotel detail)
        {
            SqlConnection sqlConnection = Connector.GetDBConnection();
            sqlConnection.Open();
            string sql = "STORED_PROCEDURE";
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                //Console.WriteLine(Printer.enterSize);
                //parameter.ParameterName = "@hotelId";
                //parameter.Value = detail.hotelId;
                //parameter.SqlDbType = SqlDbType.Int;
                //sqlCommand.Parameters.Add(parameter);
                //parameter = new SqlParameter();
                parameter.ParameterName = "@hotelName";
                parameter.Value = detail.hotelName;
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@hotelAddress";
                parameter.Value = detail.hotelAddress;
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                condition = false;
                while (condition == false)
                {
                    try
                    {
                        parameter = new SqlParameter();
                        parameter.ParameterName = "@vacantRoom";
                        parameter.Value = detail.vacantRoom;
                        parameter.SqlDbType = SqlDbType.Char;
                        parameter.Size = 20;
                        sqlCommand.Parameters.Add(parameter);
                        condition = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                condition = false;
                while (condition == false)
                {
                    try
                    {
                        parameter = new SqlParameter();
                        parameter.ParameterName = "@roomSize";
                        parameter.Value = detail.roomSize;
                        parameter.SqlDbType = SqlDbType.Int;
                        sqlCommand.Parameters.Add(parameter);
                        condition = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                parameter = new SqlParameter();
                parameter.ParameterName = "@hotelService";
                parameter.Value = detail.hotelService;
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                condition = false;
                while (condition == false)
                {
                    try
                    {
                        parameter = new SqlParameter();
                        parameter.ParameterName = "@pricePerDay";
                        parameter.Value = detail.pricePerDay;
                        parameter.SqlDbType = SqlDbType.Int;
                        sqlCommand.Parameters.Add(parameter);
                        condition = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.WriteLine(Printer.waitingMessage);
                int retRows = sqlCommand.ExecuteNonQuery();
                if (retRows >= 1)
                {
                    Console.WriteLine("Hotel Added");
                }
                else
                {
                    Console.WriteLine("Hotel not Added");
                }
                sqlCommand.Dispose();
            }
        }
    }
}
