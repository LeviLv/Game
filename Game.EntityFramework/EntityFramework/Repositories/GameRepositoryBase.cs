using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Game.EntityFramework.Repositories
{
    public abstract class GameRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<GameDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected GameRepositoryBase(IDbContextProvider<GameDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class GameRepositoryBase<TEntity> : GameRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected GameRepositoryBase(IDbContextProvider<GameDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
