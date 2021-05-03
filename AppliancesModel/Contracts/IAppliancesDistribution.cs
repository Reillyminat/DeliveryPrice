using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Contracts
{
    public interface IAppliancesDistribution
    {
        void InitializeModel();

        int RefreshStock(Appliances goods, int count);

        Appliances CheckGoodsExistance(string applianceName);

        void AddGoods(int inputType, int inputCount);

        IStockData ShowStock();
    }
}
