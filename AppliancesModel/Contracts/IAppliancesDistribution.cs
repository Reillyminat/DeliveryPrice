﻿using AppliancesModel.Data;
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
        Product RefreshStock(Product goods);

        Product CheckGoodsExistance(string applianceName);

        void AddGoods(IEnumerable<Product> products);

        void DeleteProduct(int id);

        IEnumerable<Product> GetStock();

        Product GetProduct(int id);

        void SaveStockState();
    }
}
