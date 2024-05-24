using FluentValidation;
using FluentValidation.Results;
using Micro.Seraph.AspNetCore.Controllers.Interface;
using Micro.Seraph.AspNetCore.Entity;

namespace Micro.Seraph.AspNetCore.Controllers
{
    /// <summary>
    /// 请求数据验证类
    /// </summary>
    /// <typeparam name="IValidator"></typeparam>
    /// <typeparam name="E"></typeparam>
    public class RepositoryValidation<E> : IRepositoryValidation<IValidator<E>, E> where E : class 
    {
        /// <summary>
        /// 数据校验
        /// </summary>
        /// <param name="Validation"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public ValidationResult Validate(IValidator<E> Validation, E Entity)
        {
            ValidationResult result = Validation.Validate(Entity);
            return result;
        }
    }
}