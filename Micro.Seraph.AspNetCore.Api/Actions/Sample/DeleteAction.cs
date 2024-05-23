using Micro.Seraph.AspNetCore.Entity;
using Micro.Seraph.AspNetCore.Service;
using Micro.Seraph.AspNetCore.Actions;

namespace Micro.Seraph.AspNetCore.Api.Actions.Sample
{
    public class DeleteAction : BaseAction
    {
        public override object Execute()
        {
            int intId = (int)this.GetParams();
            SampleService service = new SampleService();
            int intRes = service.DeleteSample(intId);
            return intRes;
        }
    }
}
