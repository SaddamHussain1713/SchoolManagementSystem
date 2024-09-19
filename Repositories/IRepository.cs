namespace SchoolManagementSystem.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetAddAsync(T entity);
        Task<T> GetUpdateAsync(T entity);
        Task<T> GetDeleteAsync(T entity);
    }
}
