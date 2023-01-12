using StokYonetim.BL.Abstract;
using StokYonetim.DAL.EFCore.Concrete;
using StokYonetim.Entites.Abstract;
using System.Linq.Expressions;

namespace StokYonetim.BL.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity, new()
    {
        public ManagerBase(RepostoryBase<T> repostoryBase)
        {
            RepostoryBase = repostoryBase;
        }

        public RepostoryBase<T> RepostoryBase { get; }

        public virtual async Task<int> CreateAsync(T entity)
        {
            return await RepostoryBase.CreateAsync(entity);
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            return await RepostoryBase.DeleteAsync(entity);
        }

        public virtual async Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] input)
        {
            return await RepostoryBase.FindAllIncludeAsync(filter, input);
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return await RepostoryBase.GetAllAsync(filter);
        }

        public virtual async Task<T> GetByAsync(Expression<Func<T, bool>> filter)
        {
            return await RepostoryBase.GetByAsync(filter);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
