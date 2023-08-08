namespace FakeApi.GenericRepositoryPattern.CommentByIdRemove.DAL
{
    public interface IRemove<T> where T : class
    {
        T GetById(int id);
        void Remove(T entity);
        void RemoveAll();
        IEnumerable<T> GetAll();
        
    }
}
