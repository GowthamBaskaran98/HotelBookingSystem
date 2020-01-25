using System;
namespace HotelBooking
{
    enum Options
    {
        Register = 1,
        LogIn,
        Exit
    };
    class Portal
    {
        public Portal()
        {
            try
            {
                int select;
                bool choice = true;
                UserManager register = new UserManager();
                LogInController Login = new LogInController();
                Storage storage = new Storage();
                Console.WriteLine(Printer.title);
                while (choice == true)
                {
                    int index = 1;
                    foreach (string str in Enum.GetNames(typeof(Options)))
                    {
                        Console.WriteLine(Printer.info, index, str);
                        index++;
                    }
                    select = Convert.ToInt16(Console.ReadLine());
                    if (select == 1)
                    {
                        register.Register();
                    }
                    else if (select == 2)
                    {
                        Login.LogIn();
                    }
                    else if (select == 3)
                    {
                        choice = false;
                    }
                    else
                        Console.WriteLine(Printer.invalidInput);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
