using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AlibiScript.Interface
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">實體</param>
        void Create(TEntity entity); //void可改TKey


        /// <summary>
        /// 取得全部
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 特定條件取得取得
        /// </summary>
        /// <param name="expression">查詢條件</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 刪除
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">實體</param>
        void Update(TEntity entity);
    }
}
