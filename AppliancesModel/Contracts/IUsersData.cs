﻿using AppliancesModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Contracts
{
    public interface IUsersData
    {
        ICollection<User> Users { get; set; }
    }
}