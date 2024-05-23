using System.Reflection.Metadata.Ecma335;

namespace Micro.Seraph.AspNetCore.Actions
{
    /// <summary>
    /// Action基类
    /// </summary>
    public abstract class BaseAction
    {
        //方法参数
        public object? RequestParams = null;

        public abstract object Execute();

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="objParams"></param>
        public void SetParams(object objParams)
        {
            RequestParams = objParams;
        }

        //获取参数
        public object? GetParams()
        {
            return RequestParams;
        }
    }
}
