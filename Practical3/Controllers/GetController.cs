using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Practical3.Data;
using Practical3.DataAccess.Repository.IRepository;
using Practical3.Models;

namespace Practical3.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public GetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("CategoryList")]
        public IEnumerable<Category> Category()
        {
            return _unitOfWork.Category.GetAll();
        }

        [HttpGet]
        [Route("ProductList")]
        public IEnumerable<Product> Product()
        {
            //var finalList = _unitOfWork.Product.GetAll();
            return _unitOfWork.Product.GetAll();
        }
    }
}
