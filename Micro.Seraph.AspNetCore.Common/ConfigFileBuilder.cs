using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Micro.Seraph.AspNetCore.Common
{
    public class ConfigFileBuilder
    {
        const string APPSETTING_FILENAME = "appsettings.json";

        /// <summary>
        /// 获取数据库连接配置
        /// </summary>
        /// <param name="strConnSectionName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string strConnSectionName = "ConnectionStrings:DefaultConnection")
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(APPSETTING_FILENAME, false, true);
            var configuration = configurationBuilder.Build();
            var connectionStringSection = configuration.GetSection(strConnSectionName);
            if (connectionStringSection == null || connectionStringSection.Value == null) return "";
            return connectionStringSection.Value;
        }
    }
}
