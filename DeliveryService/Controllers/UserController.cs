using AppliancesModel;
using AppliancesModel.Models;
using DeliveryServiceModel;
using EFCore5.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private DataContext context;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            context = new DataContext();
            var unitOfWork = new UnitOfWork(context,
                new UserRepository(context),
                new OrderRepository(context),
                new SupplierRepository(context),
                new TariffRepository(context),
                new CarrierRepository(context),
                new ProductRepository(context));
            var userManager = new UserManager(unitOfWork.Users, new DataSerialization(), new Cache(unitOfWork.Users.GetAll().ToList()));

            return userManager.GetAllUsers();
        }

        /* User endpoints
         * GET/User
         * PUT/User
         * POST/User
         * DELETE/User
         * 
         * Order endpoints
         * GET/Order
         * PUT/Order
         * POST/Order
         * DELETE/Order
         * 
         * Product endpoints
         * GET/Product
         * PUT/Product
         * POST/Product
         */
    }
}
