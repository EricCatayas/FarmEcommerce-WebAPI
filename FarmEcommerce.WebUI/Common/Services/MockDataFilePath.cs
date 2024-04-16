using FarmEcommerce.Core.ServiceContracts.Mock;

namespace FarmEcommerce.WebUI.Common.Services
{
    public class MockDataFilePath : IDataFilePath
    {
        public string Get()
        {
            return "Common/MockData/";
        }
    }
}
