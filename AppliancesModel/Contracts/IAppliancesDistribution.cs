using AppliancesModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Contracts
{
    public interface IAppliancesDistribution
    {
        int RefreshStock(Appliance goods, int count);

        Appliance CheckGoodsExistance(string applianceName);

        IEnumerable<Appliance> AddGoods(int inputType, int inputCount);

        IEnumerable<Appliance> ShowStock(out List<int> stockSummary);

        void SaveStockState();
    }
}
