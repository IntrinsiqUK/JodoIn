using System.Threading.Tasks;
using System.Collections.Generic;
using Jodo.Api.Client.Models.Meta;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<List<Grade>> ListGrades(string collectorCode = null);
        Task<List<object>> ListDiscounts(string collectorCode = null);
        Task<List<FeeComponent>> ListFeeComponents(string collectorCode = null);
        Task<List<Branch>> ListBranches();
    }
}
