using Domain.Abstractions;
using System.Linq.Expressions;

namespace Domain.Interfaces;
public interface IRepository<T> where T : class
{
    Task<Result<T>> GetItemAsync(Expression<Func<T, bool>> predicate);
    Task<Result<IEnumerable<T>>> GetCollectionAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includes);
    Task<Result> SaveItemAsync(T entity);
    Task<Result> UpdateItemAsync(T entity);
    Task<Result> DeleteItemAsync(int Id);
}
