using UMS.Application.Abstraction;
using UMS.Persistence;

namespace UMS.Application.Service;

public class RepositoryHelper<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    private readonly umsContext _dbContext;

    public RepositoryHelper(umsContext context)
    {
       _dbContext = context;
    }
    
    public bool CheckIfExist(long id)
    {
        if (_dbContext.Find<TEntity>(id) != null)
        {
            return true;
        }
        return false;

    }
    
    public IQueryable<TEntity> GetAll()
    {
        try
        {
            return _dbContext.Set<TEntity>();
        }
        catch (Exception)
        {
            throw new Exception("Couldn't retrieve entities");
        }
    }
    public async Task<string> AddAsync(TEntity entity)
    {
        
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
        }

        try
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return "Added Successfully";
        }
        catch (Exception)
        {
            throw new Exception($"{nameof(entity)} could not be saved");
        }
    }
    
    public async Task<string> UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
        }

        try
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

           return "Updated Successfully";
        }
        catch (Exception)
        {
            throw new Exception($"{nameof(entity)} could not be updated");
        }
    }

    public async Task<string> DeleteAsync(long id)
    {
        TEntity? entity = _dbContext.Find<TEntity>(id);
        try
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return "Removed Successfully";
        }
        catch (Exception)
        {
            throw new Exception($"{nameof(entity)} could not be deleted");
        }
    }
    
}
