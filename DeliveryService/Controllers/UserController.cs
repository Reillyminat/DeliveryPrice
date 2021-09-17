using AppliancesModel.Contracts;
using DeliveryServiceModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DeliveryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;

        public UserController(ILogger<UserController> logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userManager.GetAllUsers();
        }

        [HttpPut]
        public void Put(User user)
        {
            _userManager.EditUser(user);
        }

        [HttpPost]
        public User Post(User user)
        {
            _userManager.AddUser(user);
            return _userManager.GetUser(user);
        }

        [HttpDelete]
        public void Delete(User user)
        {
            _userManager.DeleteUser(user);
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
