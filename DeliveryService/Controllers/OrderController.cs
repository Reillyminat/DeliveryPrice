using AppliancesModel.Contracts;
using DeliveryServiceModel;
using EFCore5.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderManager _orderManager;

        public OrderController(ILogger<OrderController> logger, IOrderManager orderManager)
        {
            _logger = logger;
            _orderManager = orderManager;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderManager.GetOrders();
        }

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderManager.GetOrder(id);
        }

        [HttpPost]
        public void Post([FromBody] Order order)
        {
            _orderManager.CreateOrder(order);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order order)
        {
            _orderManager.UpdateOrder(order);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderManager.DeleteOrder(id);
        }
    }
}
