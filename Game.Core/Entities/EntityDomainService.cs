using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq.Expressions;
using Abp.Linq.Extensions;

namespace Game.Entities
{
    public abstract class EntityDomainService<TEntity> : EntityDomainService<TEntity, int> where TEntity : Entity
    {
        public EntityDomainService(IRepository<TEntity,int> repository)
            :base(repository)
        {

        }
    }
    public abstract class EntityDomainService<TEntity, TPrimaryKey> : AbpServiceBase, IEntityDomainService<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;

        public EntityDomainService(IRepository<TEntity, TPrimaryKey> Repository)
        {
            _repository = Repository;
        }



        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("GetAsync,Id:{0},Err:{1}\r\n", id, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public virtual async Task<Result> CreateAndGetIdAsync(TEntity entity)
        {
            try
            {
                var id = await _repository.InsertAndGetIdAsync(entity);
                return Result.Success(long.Parse(id.ToString()));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("CreateAndGetIdAsync,Id:{0},Err:{1}\r\n", entity.Id, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public virtual async Task<Result> CreateAsync(TEntity entity)
        {
            try
            {
                await _repository.InsertAsync(entity);
                return Result.Successed;
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("CreateAsync,Id:{0},Err:{1}\r\n", entity.Id, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public virtual async Task<Result> ModifyAsync(TEntity entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
                return Result.Successed;
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("ModifyAsync,Id:{0},Err:{1}\r\n", entity.Id, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public virtual Task<int> QueryCountAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query)
        {
            try
            {
                return Task.FromResult(_repository.Query(query).Count());
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("QueryCountAsync,Err:{0}\r\n",  ex.Message, ex.StackTrace);
                return Task.FromResult(-1);
            }
        }

        public virtual Task<int> QueryCountAsync()
        {
            try
            {
                return Task.FromResult(_repository.Count());
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("QueryCountAsync,Err:{0}\r\n", ex.Message, ex.StackTrace);
                return Task.FromResult(-1);
            }
        }

        public virtual Task<IReadOnlyList<TEntity>> QuerysListAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query, IPagedResultRequest request)
        {
            try
            {
                if (request.MaxResultCount <= 0)
                {
                    request.MaxResultCount = int.MaxValue;
                }

                var list = query == null ?
                    _repository.GetAll().OrderBy(p => p.Id).PageBy(request).ToList() :
                    _repository.Query(query).OrderBy(p => p.Id).PageBy(request).ToList();
                return Task.FromResult(list as IReadOnlyList<TEntity>);
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("QuerysListAsync,Err:{0}\r\n", ex.Message, ex.StackTrace);
                return null;
            }
        }
        

        public virtual async Task<Result> RemoveAsync(TPrimaryKey id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return Result.Successed;
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("RemoveAsync,Err:{0}\r\n", ex.Message, ex.StackTrace);
                return Result.Failed;
            }
        }

        public virtual async Task<Result> RemoveAsync(Expression<Func<TEntity, bool>> query)
        {
            try
            {
                await _repository.DeleteAsync(query);
                return Result.Successed;
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("RemoveAsync,Err:{0}\r\n", ex.Message, ex.StackTrace);
                return Result.Failed;
            }
        }
    }
}
