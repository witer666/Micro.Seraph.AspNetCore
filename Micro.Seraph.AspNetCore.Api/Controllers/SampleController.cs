using Micro.Seraph.AspNetCore.Entity;
using Micro.Seraph.AspNetCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Seraph.AspNetCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SampleController : BaseController
    {
        [HttpPut(Name = "Add")]
        //public IActionResult Add([FromServices] SampleEntity entity)
        public IActionResult Add()
        {
            int intRes = (int)this.InvokeAction(new object[] { new Entity.SampleEntity() { Title = "aaaae" } });
            return Ok(intRes);
        }

        [HttpGet(Name = "List")]
        public IActionResult List()
        {
            List<SampleEntity> listSample = (List<SampleEntity>)this.InvokeAction(new object[] { });
            return Json(listSample);
        }

        [HttpPatch(Name = "Delete")]
        public IActionResult Delete(int intId)
        {
            int intRes = (int)this.InvokeAction(new object[] { intId });
            return Ok(intRes);
        }

        [HttpPost(Name = "Update")]
        //public IActionResult Update([FromServices] SampleEntity entity)
        public IActionResult Update()
        {
            SampleEntity entity = new SampleEntity() { Id = 7, Title = "Update data"};
            int intRes = (int)this.InvokeAction(new object[] { entity });
            return Ok(intRes);
        }
    }
}
