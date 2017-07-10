using Abp.Web.Mvc.Controllers;

namespace Game.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class GameControllerBase : AbpController
    {
        protected GameControllerBase()
        {
            LocalizationSourceName = GameConsts.LocalizationSourceName;
        }
    }
}