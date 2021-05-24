﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Contracts
{
    public interface IDataSerialization
    {
        string Filename { get; set; }
        void SerializeToFile<T>(T data);
        T DeserializeFromFileOrDefault<T>(string filename);
    }
}
