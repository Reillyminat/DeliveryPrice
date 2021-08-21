using System.Collections.Generic;

namespace DeliveryServiceModel.Repo
{
    public interface IRepository
    {
        List<Product> GetProducts();
        List<Order> GetOrdersWithProducts();
        Product GetProductById(int id);
        Order GetOrderWithProductsById(int id);
        int AddProduct(Product product);
        int AddOrderWithProducts(Order order);
        int UpdateProduct(Product product);
        int UpdateOrderWithUser(Order order);
        int DeleteProduct(Product product);
        int DeleteOrderWithProducts(Order order);
    }
}
