using Micro.Seraph.AspNetCore.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Seraph.AspNetCore.Context
{
    public class BaseDbContext: DbContext
    {
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <returns>void</returns>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string strConnection = ConfigFileBuilder.GetConnectionString();
            optionsBuilder.UseMySQL(strConnection);
        }
    }
}
