using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<object> ListGrades(string collectorCode = null)
        {
            var uri = "api/v1/integrations/erp/grades";
            if (!string.IsNullOrEmpty(collectorCode))
            {
                uri += $"?collector_code={collectorCode}";
            }
            return Get<object>(uri);
        }

        public Task<object> ListDiscounts(string collectorCode = null)
        {
            var uri = "api/v1/integrations/erp/discounts";
            if (!string.IsNullOrEmpty(collectorCode))
            {
                uri += $"?collector_code={collectorCode}";
            }
            return Get<object>(uri);
        }

        public Task<object> ListFeeComponents(string collectorCode = null)
        {
            var uri = "api/v1/integrations/erp/fee-components";
            if (!string.IsNullOrEmpty(collectorCode))
            {
                uri += $"?collector_code={collectorCode}";
            }
            return Get<object>(uri);
        }

        public Task<object> ListBranches()
        {
            return Get<object>("api/v1/integrations/erp/branches");
        }
    }
}
