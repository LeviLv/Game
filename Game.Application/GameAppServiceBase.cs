using Abp.Application.Services;

namespace Game
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class GameAppServiceBase : ApplicationService
    {
        protected GameAppServiceBase()
        {
            LocalizationSourceName = GameConsts.LocalizationSourceName;
        }
    }
}