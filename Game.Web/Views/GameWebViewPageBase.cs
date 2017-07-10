using Abp.Web.Mvc.Views;

namespace Game.Web.Views
{
    public abstract class GameWebViewPageBase : GameWebViewPageBase<dynamic>
    {

    }

    public abstract class GameWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected GameWebViewPageBase()
        {
            LocalizationSourceName = GameConsts.LocalizationSourceName;
        }
    }
}