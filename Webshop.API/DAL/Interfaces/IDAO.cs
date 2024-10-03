namespace Webshop.API.DAL.Interfaces
{
    public interface IDAO<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(int id);
        Task<int> Insert(T t);
        Task<bool> Update(T t);
        Task<bool> Delete(int id);
    }
}
