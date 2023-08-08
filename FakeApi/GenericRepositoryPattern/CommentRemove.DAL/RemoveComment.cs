using FakeApi.Data;
using FakeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FakeApi.GenericRepositoryPattern.CommentByIdRemove.DAL
{

    public class RemoveComment<T> : IRemove<T> where T : class
    {
        private readonly Data.FakeApiDbContext _dbContext;

        private List<Comment> _comments = new List<Comment>();
        public RemoveComment(Data.FakeApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void RemoveAll()
        {
            var dbSet = _dbContext.Set<T>();
            dbSet.RemoveRange(dbSet);
            _dbContext.SaveChanges();
        }

        
    }
}
