using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Seraph.AspNetCore.Controllers.Interface
{
    public interface IRepositoryValidation<IValidator, E>
    {
        public ValidationResult Validate(IValidator<E> Validation, E Entity);
    }
}
