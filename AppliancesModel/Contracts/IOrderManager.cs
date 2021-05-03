using AppliancesModel.Models;

namespace AppliancesModel.Contracts
{
    public interface IOrderManager
    {
        Order CurrentOrder { get; set; }

        Order CreateShoppingBasket(User person);

        void AddItemToBasket(Appliances goods,int amount);

        void SetOrderData(string name, string address, string telephone);
    }
}
