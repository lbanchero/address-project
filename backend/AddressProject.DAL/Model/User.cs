using System;

namespace AddressProject.DAL.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string AddressStreet { get; set; }
        public double AddressLatitude { get; set; }
        public double AddressLongitude { get; set; }
        public DateTime CreationDate { get; set; }
    }
}