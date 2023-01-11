using StokYonetim.DAL.Abstract;
using StokYonetim.DAL.EFCore.Context;
using StokYonetim.Entites.Abstract;
using System.Linq.Expressions;

namespace StokYonetim.DAL.EFCore.Concrete
{
    public class RepostoryBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {
        public readonly StokYonetimDbContext dbContext;
        public RepostoryBase()
        {
            StokYonetimDbContext dbContext = new StokYonetimDbContext();
        }
        public async Task<int> CreateAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();

        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }

        public Task<IList<T>> FindAllAsnyc(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public Task<ICollection<T>> RawSqlQuery(T entity, string sql)
        {
            throw new NotImplementedException();
        }


    }
}
