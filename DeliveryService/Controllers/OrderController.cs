using AppliancesModel.Contracts;
using DeliveryServiceModel;
using EFCore5.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderManager _orderManager;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(ILogger<OrderController> logger, IOrderManager orderManager, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _orderManager = orderManager;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderManager.GetOrders();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderManager.GetOrder(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            _orderManager.CreateOrder(order);
            _unitOfWork.Save();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order order)
        {
            _orderManager.UpdateOrder(order);
            _unitOfWork.Save();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderManager.DeleteOrder(id);
            _unitOfWork.Save();
        }
    }
}
