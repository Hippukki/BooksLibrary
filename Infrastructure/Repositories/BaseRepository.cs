using Domain.Abstractions;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Query;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

internal abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;

    protected readonly ILogger<T> _logger;

    public BaseRepository(ApplicationDbContext context, ILogger<T> logger)
    {
        _context = context;
        _logger = logger;
    }

    public virtual async Task<Result<T>> GetItemAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(predicate);
            if (result is null)
                return new ErrorResult<T>(ErrorTypes.NotFound);

            return new SuccessResult<T>(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.StackTrace);
            return new ErrorResult<T>(ErrorTypes.GetError);
        }
    }

    public virtual async Task<Result<IEnumerable<T>>> GetCollectionAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includes)
    {
        try
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var result = await query.ToListAsync();

            if (result == null || !result.Any())
                return new ErrorResult<IEnumerable<T>>(ErrorTypes.NotFound);

            return new SuccessResult<IEnumerable<T>>(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.StackTrace);
            return new ErrorResult<IEnumerable<T>>(ErrorTypes.GetError);
        }
    }

    public virtual async Task<Result> SaveItemAsync(T entity)
    {
        try
        {
            _context.Set<T>().Attach(entity);
            var result = await _context.SaveChangesAsync();
            if (result is 0)
                return new ErrorResult(ErrorTypes.InsertError);

            return new SuccessResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResult(ex.Message);
        }
    }

    public virtual async Task<Result> UpdateItemAsync(T entity)
    {
        try
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return new SuccessResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResult(ex.Message);
        }
    }

    public virtual async Task<Result> DeleteItemAsync(int Id)
    {
        try
        {
            var dbSet = _context.Set<T>();
            var item = await dbSet.FindAsync(Id);
            if (item is null)
                return new ErrorResult<IEnumerable<T>>(ErrorTypes.NotFound);

            dbSet.Remove(item);
            await _context.SaveChangesAsync();

            return new SuccessResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResult(ex.Message);
        }
    }

    public virtual async Task<Result> ClearTableAsync()
    {
        try
        {
            var dbSet = _context.Set<T>();
            dbSet.RemoveRange(dbSet);
            await _context.SaveChangesAsync();

            return new SuccessResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResult(ex.Message);
        }
    }
}
