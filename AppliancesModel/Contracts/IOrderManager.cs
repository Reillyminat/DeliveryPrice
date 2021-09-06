using DeliveryServiceModel;

namespace AppliancesModel.Contracts
{
    public interface IOrderManager
    {
        Order CurrentOrder { get; set; }

        Order CreateShoppingBasket(User person);

        void AddItemToBasket(Product product, int amount);

        void SetOrderData(string name, string address, string phone);

        void SaveOrdersState();
    }
}
