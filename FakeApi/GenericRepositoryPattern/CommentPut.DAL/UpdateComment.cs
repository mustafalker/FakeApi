using FakeApi.Data;
using FakeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FakeApi.GenericRepositoryPattern.CommentPut.DAL
{
    public class UpdateComment<T> : IUpdate<T> where T : class
    {
        private readonly Data.FakeApiDbContext _dbContext;

        private List<Comment> _comments = new List<Comment>();
        public UpdateComment(Data.FakeApiDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
