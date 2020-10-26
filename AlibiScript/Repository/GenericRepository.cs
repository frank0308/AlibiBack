using AlibiScript.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AlibiScript.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly object DBcontext;
        protected object Context { get { return DBcontext; } }
        public GenericRepository(object DB) {
            DBcontext = DB;
        }

        public void Create(TEntity entity)
        {

        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
