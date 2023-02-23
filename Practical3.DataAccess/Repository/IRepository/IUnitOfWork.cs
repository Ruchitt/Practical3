using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical3.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get;}
        IProductRepository Product { get;}
        IOrderRepository Order { get; }
        IOrderItemsRepository OrderItems { get; }
        void Save();

    }
}
