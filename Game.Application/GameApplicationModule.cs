using System.Reflection;
using Abp.Modules;

namespace Game
{
    [DependsOn(typeof(GameCoreModule))]
    public class GameApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
