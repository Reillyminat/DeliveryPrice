using System;

namespace AppliancesModel
{
    public class User
    {
        public string name { get; set; }
        public bool administratorRights { get; }
        public DateTime birthDate { get; set; }
        int id;
        public User(int id, bool administratorRoot, DateTime birthDate, string name)
        {
            this.id = id;
            this.name = name;
            this.administratorRights = administratorRoot;
            this.birthDate = birthDate;
        }
    }
}
