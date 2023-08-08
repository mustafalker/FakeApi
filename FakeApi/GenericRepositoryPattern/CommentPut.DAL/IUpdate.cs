using FakeApi.Model;

namespace FakeApi.GenericRepositoryPattern.CommentPut.DAL
{
    public interface IUpdate<T> where T : class
    {
        T GetById(int id);
        void Update(T entity);
    }
}
