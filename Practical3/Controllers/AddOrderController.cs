using IdentityCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Practical3.DataAccess.Repository;
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
        public async Task<ActionResult> Post(OrderVM model)
        {
            // Check if user exists
            var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return Unauthorized();
            //}

            // Add order to the repository
            var order = new Order
            {
                OrderDate = DateTime.Now,
                Note = model.Note,
                DiscountAmount = model.DiscountAmount,
                Status = StatusType.Open,
                TotalAmount = model.TotalAmount,
                CustomerName = model.CustomerName,
                CustomerEmail = string.IsNullOrEmpty(model.CustomerEmail) ? user.Email : model.CustomerEmail,
                CustomerContactNo = model.CustomerContactNo,
                IsActive = true,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            _unitOfWork.Order.Add(order);
            _unitOfWork.Save();
            // Add order items to the repository
            var orderItems = new List<OrderItems>();
            foreach (var item in model.OrderItems)
            {
                
                var product = _unitOfWork.Product.GetFirstOrDefault(x => x.ProductId == model.ProductId);
                if (product == null)
                {
                    return BadRequest($"Product with id {model.ProductId} not found");
                }
                if (product.Quantity < item.Quantity)
                {
                    return BadRequest($"Product with id {item.ProductId} does not have enough quantity");
                }
                var orderItem = new OrderItems
                {
                    OrderId = order.OrderId,
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    Price = product.Price,
                    IsActive = true
                };
                orderItems.Add(orderItem);
            }
            foreach (var item in orderItems)
            {
                _unitOfWork.OrderItems.Add(item);
            }
            _unitOfWork.Save();
            return Ok($"Order with id {order.OrderId} added successfully");
        }

        [HttpPost]
        [Route("Filters")]
        public IActionResult GetAllOrders(DateTime? fromDate, DateTime? toDate, StatusType? statusType, string? customerSearch)
        {

            // Get orders from the repository
            var orders = _unitOfWork.Order.GetAll();

                // Apply filters if provided
                if (fromDate != null)
                {
                    orders = orders.Where(o => o.CreatedOn >= fromDate.Value);
                }
                if (toDate != null)
                {
                    orders = orders.Where(o => o.CreatedOn <= toDate.Value);
                }
                if (statusType != null)
                {
                    orders = orders.Where(o => o.Status == statusType.Value);
                }
                if (!string.IsNullOrEmpty(customerSearch))
                {
                    orders = orders.Where(o => o.CustomerName.ToLower().Contains(customerSearch.ToLower())
                                         || o.CustomerEmail.ToLower().Contains(customerSearch.ToLower())
                                         || o.CustomerContactNo.ToLower().Contains(customerSearch.ToLower()));
                }

                // Project orders into OrderViewModels
                var orderViewModels = orders.Select(o => new Order
                {
                    OrderId = o.OrderId,
                    CreatedOn = o.CreatedOn,
                    CustomerName = o.CustomerName,
                    CustomerEmail = o.CustomerEmail,
                    CustomerContactNo = o.CustomerContactNo,
                    Status = o.Status,
                    TotalAmount = o.TotalAmount,
                    DiscountAmount = o.DiscountAmount,
                    Note = o.Note
                }).ToList();

                return Ok(orderViewModels);
        }

    }
}
