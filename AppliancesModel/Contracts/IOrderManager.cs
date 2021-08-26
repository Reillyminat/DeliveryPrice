using AppliancesModel.Models;
using DeliveryServiceModel;

namespace AppliancesModel.Contracts
{
    public interface IOrderManager
    {
        Order CurrentOrder { get; set; }

        Order CreateShoppingBasket(User person);

        void AddItemToBasket(Product goods,int amount);

        void SetOrderData(string name, string address, string telephone);

        void SaveOrdersState();
    }
}
