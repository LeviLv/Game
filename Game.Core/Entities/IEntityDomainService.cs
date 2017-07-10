using Abp.Application.Services.Dto;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    public interface IEntityDomainService<TEntity> : IEntityDomainService<TEntity, int>
    {

    }
    public interface IEntityDomainService<TEntity, TPrimaryKey> : IDomainService
    {
        /// <summary>
        /// 通过ID获取领域实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TPrimaryKey id);

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Result> CreateAsync(TEntity entity);

        /// <summary>
        /// 创建实体并获取ID
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Result> CreateAndGetIdAsync(TEntity entity);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Result> ModifyAsync(TEntity entity);

        /// <summary>
        /// 通过ID删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> RemoveAsync(TPrimaryKey id);

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<Result> RemoveAsync(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// 根据条件分页查询实体
        /// </summary>
        /// <param name="query"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IReadOnlyList<TEntity>> QuerysListAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query, IPagedResultRequest request);
       

        /// <summary>
        /// 根据条件统计实体数量
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<int> QueryCountAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query);

        /// <summary>
        /// 统计所有实体数量
        /// </summary>
        /// <returns></returns>
        Task<int> QueryCountAsync();
    }
}
