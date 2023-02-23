using IdentityCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Practical3.DataAccess.Repository.IRepository;
using Practical3.Models;
using Practical3.Models.ViewModels;
using System.Collections.Generic;
using System.Collections.Specialized;
using static Practical3.Models.Order;

namespace Practical3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddOrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AddOrderController(IUnitOfWork unitOfWork,UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("Add OrderItem")]
        public async Task<ActionResult> Post(OrderItemVM model)
        {
            int a1 = 0;
            if (User.Identity.IsAuthenticated)
            {
                var userdata = await _userManager.FindByNameAsync(User.Identity.Name);

                if (userdata == null)
                {
                    return BadRequest("No User Found");
                }

                var check = _unitOfWork.Order.GetFirstOrDefault(x => x.CustomerName == userdata.UserName);
                var order = new Order();
                if (check == null)
                {
                    order.CustomerName = userdata.UserName;
                    if (model.Name != null)
                    {
                        order.CustomerName = model.Name;
                    }
                    order.CustomerEmail = userdata.Email;
                    if (model.Email != null)
                    {
                        order.CustomerEmail = model.Email;
                    }
                    order.CustomerContactNo = userdata.PhoneNumber;
                    order.Note = model.ProductId.ToString();
                    order.IsActive = true;
                    order.DisountAmount = 0;


                    _unitOfWork.Order.Add(order);
                    a1 = order.OrderId;
                    _unitOfWork.Save();
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Meessage = "Order added Succesfully" });
                }

                var orderitemdata = new OrderItems()
                {
                    Quantity = model.Quantity,
                    OrderId = a1,
                    ProductId = model.ProductId,
                    
                };

                _unitOfWork.OrderItems.Add(orderitemdata);
                _unitOfWork.Save();
            }
            else
            {
                var order = new Order();
                order.CustomerName = model.Name;
                order.CustomerEmail = model.Email;
                order.CustomerContactNo = model.PhoneNumber;
                order.Note = model.ProductId.ToString();
                order.IsActive = true;
                order.DisountAmount = 0;

                _unitOfWork.Order.Add(order);
                _unitOfWork.Save();

                var orderitemdata = new OrderItems()
                {
                    Quantity = model.Quantity,
                    OrderId = a1,
                    ProductId = model.ProductId,
                    Price=123
                };

                _unitOfWork.OrderItems.Add(orderitemdata);
                _unitOfWork.Save();
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Meessage = "Order added Succesfully" });
            }
            return Ok(new Response { Status = "Error", Meessage = "Please Try Again " });
        }

            

    }
}
