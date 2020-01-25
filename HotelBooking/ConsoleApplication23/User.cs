using System;
namespace HotelBooking
{
    class User
    {
        public string userId { get; set; }
        public string mobileNumber { get; set; }
        public string password { get; set; }
        public string userType { get; set; }
        public User(string userId, string mobileNumber, string password, string userType)
        {
            this.userId = userId;
            this.mobileNumber = mobileNumber;
            this.password = password;
            this.userType = userType;
        }
        public User(string userId, string password)
        {
            this.userId = userId;
            this.password = password;
        }
        public override string ToString()
        {
            Console.WriteLine("User Name is                        : {0}", userId);
            Console.WriteLine("Mobile number is                    : {0}", mobileNumber);
            Console.WriteLine("Password is                         : {0}", password);
            return "";
        }
    }
}
