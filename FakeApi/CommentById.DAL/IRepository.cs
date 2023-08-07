namespace FakeApi.CommentById.DAL
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        void Remove(T entity);
    }
}
