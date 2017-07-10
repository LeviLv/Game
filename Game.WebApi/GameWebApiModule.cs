using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace Game
{
    [DependsOn(typeof(AbpWebApiModule), typeof(GameApplicationModule))]
    public class GameWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(GameApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
