using Micro.Seraph.AspNetCore.Entity;
using Micro.Seraph.AspNetCore.Service;

namespace Micro.Seraph.AspNetCore.Api.Actions.Sample
{
    public class ListAction: BaseAction
    {
        public override object Execute()
        {
            SampleService service = new SampleService();
            List<SampleEntity> listSample = service.GetListSample();
            return listSample;
        }
    }
}
