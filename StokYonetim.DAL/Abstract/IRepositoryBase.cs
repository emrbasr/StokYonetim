using StokYonetim.Entites.Abstract;
using System.Linq.Expressions;

namespace StokYonetim.DAL.Abstract
{
    public interface IRepositoryBase<T> where T : BaseEntity, new()
    {
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);


        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> filter = null);
        Task<IList<T>> FindAllAsnyc(Expression<Func<T, bool>> filter = null);

        Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null
            , params Expression<Func<T, object>>[] include);
        Task<ICollection<T>> RawSqlQuery(T entity, string sql);
    }
}
