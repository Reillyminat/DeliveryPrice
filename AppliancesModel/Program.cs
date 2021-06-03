using AppliancesModel.Contracts;
using AppliancesModel.Data;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            var startup = new AppliancesDistribution();
            SelectAction(startup);
        }
    }
}