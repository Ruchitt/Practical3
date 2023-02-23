using Practical3.Models;
using Practical3.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical3.DataAccess.Repository.IRepository
{
    public interface IProductRepository:IRepository<Product>
    {
    }
}
