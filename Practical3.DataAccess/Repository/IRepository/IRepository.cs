using System.Linq.Expressions;

namespace Practical3.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

    }
}
