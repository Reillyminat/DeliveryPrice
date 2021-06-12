using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Contracts
{
    public interface ILogger:IDisposable
    {
        void AddLog(string data);
    }
}
