using System;   
namespace HotelBooking
{
    class Hotel
    {
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public string ownerName { get; set; }
        public string hotelAddress { get; set; }
        public short vacantRoom { get; set; }
        public short roomSize { get; set; }
        public string hotelService { get; set; }
        public int pricePerDay { get; set; }
        public string name { get; set; }
        public double mobileNumber { get; set; }
        public string password { get; set; }
        public string userType { get; set; }
        public Hotel(string name, double mobileNumber, string password, string userType)
        {
            this.name = name;
            this.mobileNumber = mobileNumber;
            this.password = password;
            this.userType = userType;
        }
        public Hotel(int hotelId,string hotelName, string ownerName, string hotelAddress, short vacantRoom, short roomSize, string hotelService, int pricePerDay)
        {
            this.hotelId = hotelId;
            this.hotelName = hotelName;
            this.ownerName = ownerName;
            this.hotelAddress = hotelAddress;
            this.vacantRoom = vacantRoom;
            this.roomSize = roomSize;
            this.hotelService = hotelService;
            this.pricePerDay = pricePerDay;
        }
        public override string ToString()
        {
            Console.WriteLine("Hotel ID is                      : {0}", hotelId);
            Console.WriteLine("Hotel Name is                    : {0}", hotelName);
            Console.WriteLine("Hotel Address is                 : {0}", hotelAddress);
            Console.WriteLine("Vacant Rooms is                  : {0}", vacantRoom);
            Console.WriteLine("Room Size is                     : {0}", roomSize);
            Console.WriteLine("Service                          : {0}", hotelService);
            Console.WriteLine("Price per Day is                 : {0}", pricePerDay);
            return "";
        }
    }
}
