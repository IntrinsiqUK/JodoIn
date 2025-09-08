using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<object> ListGrades(string collectorCode = null);
        Task<object> ListDiscounts(string collectorCode = null);
        Task<object> ListFeeComponents(string collectorCode = null);
        Task<object> ListBranches();
    }
}
