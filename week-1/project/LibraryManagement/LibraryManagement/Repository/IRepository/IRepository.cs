namespace LibraryManagement.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(int index);
        List<T> GetAll();
    }
}
