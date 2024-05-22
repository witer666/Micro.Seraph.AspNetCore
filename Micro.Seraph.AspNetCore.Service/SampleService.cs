using Micro.Seraph.AspNetCore.Context;
using Micro.Seraph.AspNetCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Seraph.AspNetCore.Service
{
    public class SampleService
    {
        public int AddSample(SampleEntity sampleEntity)
        {
            SampleContext context = new SampleContext();
            int intRes = context.AddSample(sampleEntity);
            return intRes;
        }

        public List<SampleEntity> GetListSample()
        {
            SampleContext context = new SampleContext();
            List<SampleEntity> listSample = context.GetListSample();
            return listSample;
        }

        public int DeleteSample(int intId)
        {
            SampleContext context = new SampleContext();
            int intRes = context.DeleteSample(intId);
            return intRes;
        }

        public int UpdateSample(SampleEntity entity)
        {
            SampleContext context = new SampleContext();
            int intRes = context.UpdateSample(entity);
            return intRes;
        }
    }
}
