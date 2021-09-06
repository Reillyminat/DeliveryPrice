using AppliancesModel.Data;
using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Contracts
{
    public interface IAppliancesDistribution
    {
        int RefreshStock(Product goods, int count);

        Product CheckGoodsExistance(string applianceName);

        IEnumerable<Product> AddGoods(int inputType, int inputCount);

        IEnumerable<Product> GetStock(out List<int> stockSummary);

        void SaveStockState();
    }
}
