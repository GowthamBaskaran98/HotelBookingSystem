using System;
enum lists
{
    Customer = 1,
    HotelOwner
};
namespace HotelBooking
{
    class UserManager 
    {
        public string userId;
        public string mobileNumber;
        public string password;
        public string userType;
        public int select;
        public bool state;
        public User register;
        public void Register()
        {
            try
            {
                Validation validate = new Validation();
                state = false;
                while (state == false)
                {
                    Console.WriteLine(Printer.enterName);
                    userId = Console.ReadLine();
                    state = validate.CheckName(userId);
                }
                state = false;
                while (state == false)
                {
                    Console.WriteLine(Printer.enterMobileNumber);
                    mobileNumber = Console.ReadLine();
                    state = validate.CheckMobileNumber(mobileNumber);
                }
                state = false;
                while (state == false)
                {
                    Console.WriteLine(Printer.enterPassword);
                    password = Console.ReadLine();
                    state = validate.CheckPassword(password);
                }
                state = false;
                while (state == false)
                {
                    int index = 1;
                    foreach (string str in Enum.GetNames(typeof(lists)))
                    {
                        Console.WriteLine("Press {0} for register as {1} ", index, str);
                        index++;
                    }
                    select = Convert.ToInt16(Console.ReadLine());
                    if (select == 1)
                    {
                        userType = "Customer";
                        state = true;
                    }
                    else if (select == 2)
                    {
                        userType = "HotelOwner";
                        state = true;
                    }
                    else
                    {
                        state = false;
                        Console.WriteLine(Printer.invalidInput);
                    }
                }
                User user = new User(userId, mobileNumber, password, userType);
                UserRepository userRepository = new UserRepository(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message+" "+e.StackTrace);
                Console.ReadLine();
            }
        }
        //public void DisplayCustomerList()
        //{
        //    foreach (Registration k in userList)
        //    {
        //        if (k.userType == "Customer")
        //        {
        //            k.ToString();
        //        }
        //    }
        //}
    }
}
