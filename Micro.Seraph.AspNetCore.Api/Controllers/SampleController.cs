using FluentValidation;
using Micro.Seraph.AspNetCore.Controllers;
using Micro.Seraph.AspNetCore.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Seraph.AspNetCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SampleController : BaseController<SampleEntity>
    {
        private IValidator<SampleEntity> _validator;
        public SampleController(IValidator<SampleEntity> validator)
        {
            _validator = validator;
        }

        [HttpPut(Name = "Add")]
        //public IActionResult Add([FromServices] SampleEntity entity)
        public IActionResult Add()
        {
            SampleEntity entity = new Entity.SampleEntity() { Title = "aaaaa6" };
            bool bolIsValid = this.IsValid(_validator, entity);
            if (!bolIsValid)
            {
                return BadRequest();
            }

            int intRes = (int)this.Invoke(new object[] { entity });
            return Ok(intRes);
        }

        [HttpGet(Name = "List")]
        public IActionResult List()
        {
            List<SampleEntity> listSample = (List<SampleEntity>)this.Invoke(new object[] { });
            return Json(listSample);
        }

        [HttpPatch(Name = "Delete")]
        public IActionResult Delete(int intId)
        {
            int intRes = (int)this.Invoke(new object[] { intId });
            return Ok(intRes);
        }

        [HttpPost(Name = "Update")]
        //public IActionResult Update([FromServices] SampleEntity entity)
        public IActionResult Update()
        {
            SampleEntity entity = new SampleEntity() { Id = 7, Title = "Update data" };
            int intRes = (int)this.Invoke(new object[] { entity });
            return Ok(intRes);
        }
    }
}
