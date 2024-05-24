using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Seraph.AspNetCore.Entity
{
    public class SampleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public class SampleValidator : AbstractValidator<SampleEntity>
    {
        public SampleValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Title).Length(1, 255);
        }
    }
}
