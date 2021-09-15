using AppliancesModel.Contracts;
using AppliancesModel.Models;
using DeliveryServiceModel;
using EFCore5.Data;
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
        private readonly IUnitOfWork _unitOfWork;

        public UserController(ILogger<UserController> logger,IUserManager userManager, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
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
            _unitOfWork.Save();
        }

        [HttpPost]
        public User Post(User user)
        {
            _userManager.AddUser(user);
            _unitOfWork.Save();
            return _userManager.GetUser(user);
        }

        [HttpDelete]
        public void Delete(User user)
        {
            _userManager.DeleteUser(user);
            _unitOfWork.Save();
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
