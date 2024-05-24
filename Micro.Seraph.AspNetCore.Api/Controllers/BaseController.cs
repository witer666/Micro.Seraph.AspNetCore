using Micro.Seraph.AspNetCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Seraph.AspNetCore.Api.Controllers
{
    [ApiController]
    public class BaseController<E> : BootstrapController<E> where E : class
    {
        [NonAction]
        public override Type GetActionType(string strActionClassName)
        {
            return Type.GetType(strActionClassName);
        }

        [NonAction]
        public override object GetActionInstance(Type typeClass)
        {
            return Activator.CreateInstance(typeClass);
        }
    }
}
