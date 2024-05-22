using Micro.Seraph.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Seraph.AspNetCore.Context
{
    public class SampleContext: BaseDbContext
    {
        public DbSet<SampleEntity> Sample { get; set; }

        public SampleContext() { }

        public int AddSample(SampleEntity entity)
        {
            Sample.Add(entity);
            int res = SaveChanges();
            return res;
        }

        public List<SampleEntity> GetListSample()
        {
            List<SampleEntity> listSample = Sample.ToList();
            return listSample;
        }

        public int DeleteSample(int intId)
        {
            Sample.Remove(Sample.Where(o => o.Id == intId).ToList()[0]);

            int res = SaveChanges();
            return res;
        }

        public int UpdateSample(SampleEntity entity)
        {
            Sample.Update(entity);
            int res = SaveChanges();
            return res;
        }
    }
}
