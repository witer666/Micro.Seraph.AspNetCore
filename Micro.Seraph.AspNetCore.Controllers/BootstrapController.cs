using FluentValidation;
using Micro.Seraph.AspNetCore.Controllers.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Reflection;
using Micro.Seraph.AspNetCore.Entity;
using FluentValidation.Results;

namespace Micro.Seraph.AspNetCore.Controllers
{
    [ApiController]
    public abstract class BootstrapController<E> : Controller where E : class
    {
        /// <summary>
        /// 根据路由利用反射动态调用Action类
        /// </summary>
        /// <param name="objParams"></param>
        /// <returns></returns>
        [NonAction]
        public object Invoke(object[] objParams)
        {
            RouteData routeData = ControllerContext.RouteData;
            string strActionName = string.Format("{0}Action", Common.Functions.ToFirstWordUpper(routeData.Values["action"].ToString()));
            string strActionClassName = string.Format("{0}.{1}.{2}", Common.Constant.ACTION_NAMESPACE_PREFIX,
                Common.Functions.ToFirstWordUpper(routeData.Values["controller"].ToString()),
                strActionName);
            Type typeClass = this.GetActionType(strActionClassName);
            object objInstance = this.GetActionInstance(typeClass);
            if (0 < objParams.Count())
            {
                MethodInfo paramsMethodInfo = typeClass.GetMethod("SetParams");
                paramsMethodInfo.Invoke(objInstance, objParams);
            }
            MethodInfo classMethodInfo = typeClass.GetMethod("Execute");
            object objResult = classMethodInfo.Invoke(objInstance, null);
            return objResult;
        }

        /// <summary>
        /// 请求数据校验
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [NonAction]
        public bool IsValid(IValidator<E> validator, E entity)
        {
            RepositoryValidation<E> repositoryValidation = new RepositoryValidation<E>();
            ValidationResult result = repositoryValidation.Validate(validator, entity);
            return result.IsValid;
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
