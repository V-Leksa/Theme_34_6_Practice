
namespace Theme_34_6_Practice
{
    public interface ICRUDable<T>
    {
        Task AddAsync(T entity);
        Task<T> ReadAsync(string firstName, string lastName);
        Task <IEnumerable<T>> FindAsync(Func<T,bool>predicate);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string firstName, string lastName);
    }
}
