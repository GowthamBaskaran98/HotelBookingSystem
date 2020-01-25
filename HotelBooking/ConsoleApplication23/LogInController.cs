using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace HotelBooking
{
    class LogInController : UserManager
    {
        public int count;
        public static List<User> userList = new List<User>();
        CustomerRepository customer = new CustomerRepository();
        HotelManager hotels = new HotelManager();
        //public LogInController()
        //{
        //    register = new Registration("admin", "8778613988", "admin", "Admin");
        //    userList.Add(register);
        //}
        public void LogIn()
        {
            count = 0;
            Console.WriteLine(Printer.enterName);
            userId = Console.ReadLine();
            Console.WriteLine(Printer.enterPassword);
            password = Console.ReadLine();
            SqlConnection sqlConnection = Connector.GetDBConnection();
            string sql = "Select * From USER_LOGIN";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter myAdapter = new SqlDataAdapter(sqlCommand);
            DataSet MyDataSet = new DataSet();
            myAdapter.Fill(MyDataSet, "Departments");
            foreach (DataRow myRow in MyDataSet.Tables[0].Rows)
            {
                User register = new User(myRow[0].ToString().Trim(),myRow[1].ToString().Trim(),myRow[2].ToString().Trim(), myRow[3].ToString().Trim());
                userList.Add(register);
            }
            foreach (User r in userList)
            {
                if (r.userId == userId && r.password == password)
                {
                    if (r.userType.Equals("Customer"))
                    {
                        Console.WriteLine(Printer.validLogin);
                        customer.CustomerRepositor(userId);
                        count++;
                        break;
                    }
                    else if (r.userType.Equals("HotelOwner"))
                    {
                        count = 0;
                        Console.WriteLine(Printer.validLogin);
                        foreach (Hotel h in HotelManager.request)
                        {
                            if (h.ownerName == userId)
                            {
                                Console.WriteLine(Printer.requestMessage);
                                count++;
                            }
                        }
                        foreach (Hotel h in HotelManager.hotelList)
                        {
                            if (h.ownerName == userId)
                            {
                                hotels.Manage(userId);
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            hotels.RegisterHotelDetail(userId);
                            count++;
                        }
                    }
                    else if (r.userType.Equals("Admin"))
                    {
                        AdminRepository admin = new AdminRepository();
                        count++;
                        break;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine(Printer.invalidLogin);
        }
    }
}
