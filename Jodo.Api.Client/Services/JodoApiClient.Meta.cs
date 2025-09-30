using System.Threading.Tasks;
using System.Collections.Generic;
using Jodo.Api.Client.Models.Meta;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<List<Grade>> ListGrades(string collectorCode = null)
        {
            var uri = "api/v1/integrations/erp/grades";
            if (!string.IsNullOrEmpty(collectorCode))
            {
                uri += $"?collector_code={collectorCode}";
            }
            return GetFromEnvelope<List<Grade>>(uri);
        }

        public Task<List<object>> ListDiscounts(string collectorCode = null)
        {
            var uri = "api/v1/integrations/erp/discounts";
            if (!string.IsNullOrEmpty(collectorCode))
            {
                uri += $"?collector_code={collectorCode}";
            }
            return GetFromEnvelope<List<object>>(uri);
        }

        public Task<List<FeeComponent>> ListFeeComponents(string collectorCode = null)
        {
            var uri = "api/v1/integrations/erp/fee-components";
            if (!string.IsNullOrEmpty(collectorCode))
            {
                uri += $"?collector_code={collectorCode}";
            }
            return GetFromEnvelope<List<FeeComponent>>(uri);
        }

        public Task<List<Branch>> ListBranches()
        {
            return GetFromEnvelope<List<Branch>>("api/v1/integrations/erp/branches");
        }
    }
}
