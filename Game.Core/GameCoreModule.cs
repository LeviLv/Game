using System.Reflection;
using Abp.Modules;

namespace Game
{
    public class GameCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
