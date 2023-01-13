using StokYonetim.BL.Abstract;
using StokYonetim.DAL.EFCore.Concrete;
using StokYonetim.DAL.EFCore.Context;
using StokYonetim.Entites.Abstract;
using System.Linq.Expressions;

namespace StokYonetim.BL.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity, new()
    {
        public ManagerBase(StokYonetimDbContext dbContext)
        {
            RepositoryBase = new RepostoryBase<T>(dbContext);
        }

        public RepostoryBase<T> RepositoryBase { get; }

        public virtual async Task<int> CreateAsync(T entity)
        {
            return await RepositoryBase.CreateAsync(entity);
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            return await RepositoryBase.DeleteAsync(entity);
        }

        public virtual async Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] input)
        {
            return await RepositoryBase.FindAllIncludeAsync(filter, input);
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return await RepositoryBase.GetAllAsync(filter);
        }

        public virtual async Task<T?> GetByAsync(Expression<Func<T, bool>> filter)
        {
            return await RepositoryBase.GetByAsync(filter);
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await RepositoryBase.GetByIdAsync(id);
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            return await RepositoryBase.UpdateAsync(entity);
        }
    }
}
