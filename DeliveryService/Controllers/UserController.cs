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
         * GET/User/Id
         * PUT/User
         * POST/User
         * DELETE/User/Id
         * 
         * Order endpoints
         * GET/Order
         * GET/Order/Id
         * PUT/Order/Id
         * POST/Order
         * DELETE/Order/Id
         * 
         * Product endpoints
         * GET/Product
         * GET/Product/Id
         * PUT/Product/Id
         * POST/Product
         */
    }
}
