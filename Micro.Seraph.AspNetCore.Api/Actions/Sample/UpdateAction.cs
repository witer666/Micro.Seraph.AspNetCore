using Micro.Seraph.AspNetCore.Entity;
using Micro.Seraph.AspNetCore.Service;
using Micro.Seraph.AspNetCore.Actions;

namespace Micro.Seraph.AspNetCore.Api.Actions.Sample
{
    public class UpdateAction : BaseAction
    {
        public override object Execute()
        {
            SampleEntity entity = (SampleEntity)this.GetParams();
            SampleService service = new SampleService();
            int intRes = service.UpdateSample(entity);
            return intRes;
        }
    }
}
