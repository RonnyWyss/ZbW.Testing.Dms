using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
    class AppSettingService:IAppSettingService
    {
        public string GetRepositoryDir()
        {
            var value = ConfigurationManager.AppSettings["RepositoryDir"];
            return value;
        }
    }
}
