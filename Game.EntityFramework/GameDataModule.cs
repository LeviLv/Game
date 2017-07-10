using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Game.EntityFramework;

namespace Game
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(GameCoreModule))]
    public class GameDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<GameDbContext>(null);
        }
    }
}
