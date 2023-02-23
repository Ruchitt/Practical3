using Practical3.Data;
using Practical3.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical3.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product= new ProductRepository(_db);
            Order= new OrderRepository(_db);
            OrderItems= new OrderItemsRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IProductRepository Product { get; private set; }
        public IOrderItemsRepository OrderItems { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
