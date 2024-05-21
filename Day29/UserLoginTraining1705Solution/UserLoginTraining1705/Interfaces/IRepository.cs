namespace UserLoginTraining1705.Interfaces
{
    public interface IRepository<K,T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Delete(K key);
        Task<T> Update(T entity);
        Task<T> Get(K key);
        Task<T> GetAll();
        Task<T> GetUserByMail(string email);
    }
}
