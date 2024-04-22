namespace PizzaStoreDALLibrary
{
    public interface IRepository<Key, Class> where Class : class
    {
        List<Class> GetAll();
        Class Get(Key key);
        Class Add(Class item);
        Class Update(Class item);
        Class Delete(int key);
    }
}
