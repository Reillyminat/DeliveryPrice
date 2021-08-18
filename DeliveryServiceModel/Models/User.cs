﻿namespace DeliveryServiceModel
{
    public class User
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string FullName { get; set; }

        public string Telephone { get; set; }

        public int Age { get; set; }

        public bool IsLocal { get { return Address.Contains("Днепр"); } set { IsLocal= Address.Contains("Днепр"); } }
    }
}
