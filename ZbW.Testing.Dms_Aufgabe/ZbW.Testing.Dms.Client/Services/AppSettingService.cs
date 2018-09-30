using System.Configuration;

namespace ZbW.Testing.Dms.Client.Services
{
    internal class AppSettingService : IAppSettingService
    {
        public string GetRepositoryDir()
        {
            var value = ConfigurationManager.AppSettings["RepositoryDir"];
            return value;
        }
    }
}