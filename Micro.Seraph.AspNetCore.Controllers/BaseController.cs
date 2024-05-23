using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace Micro.Seraph.AspNetCore.Controllers
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// 根据路由利用反射动态调用Action类
        /// </summary>
        /// <param name="objParams"></param>
        /// <returns></returns>
        [NonAction]
        public object InvokeAction(object[] objParams)
        {
            RouteData routeData             = ControllerContext.RouteData;
            string strActionName            = string.Format("{0}Action", Common.Functions.ToFirstWordUpper(routeData.Values["action"].ToString()));
            string strActionClassName       = string.Format("{0}.{1}.{2}", Common.Constant.ACTION_NAMESPACE_PREFIX,
                Common.Functions.ToFirstWordUpper(routeData.Values["controller"].ToString()),
                strActionName);
            Type typeClass                  = this.GetActionType(strActionClassName);
            object objInstance              = this.GetActionInstance(typeClass);
            if (0 < objParams.Count())
            {
                MethodInfo paramsMethodInfo = typeClass.GetMethod("SetParams");
                paramsMethodInfo.Invoke(objInstance, objParams);
            }
            MethodInfo classMethodInfo  = typeClass.GetMethod("Execute");
            object objResult            = classMethodInfo.Invoke(objInstance, null);
            return objResult;
        }

        /// <summary>
        /// 获取Action类型
        /// </summary>
        /// <param name="strActionClassName"></param>
        /// <returns></returns>
        [NonAction]
        public abstract Type GetActionType(string strActionClassName);

        /// <summary>
        /// 获取Action实例对象
        /// </summary>
        /// <param name="typeClass"></param>
        /// <returns></returns>
        [NonAction]
        public abstract object GetActionInstance(Type typeClass);
    }
}
