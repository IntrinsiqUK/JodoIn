using Jodo.Api.Client.Models.Shared;
using Jodo.Api.Client.Models.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<RegisterStudentResponse> RegisterStudent(string registrationId, RegisterStudentRequest request);
        Task<ApiResponse> UpdateStudent(string jodoStudentId, UpdateStudentRequest request);
        Task<ApiResponse> UpdateStudentFee(string jodoStudentId, UpdateStudentFeeRequest request);
        Task<GetStudentDetailsResponse> GetStudentDetails(string jodoStudentId);
        Task<ApiResponse> PostPayment(string jodoStudentId, PostPaymentRequest request);
        Task CancelPayment(string jodoStudentId, string transactionId);
        Task<List<object>> ListStudentPayments(string jodoStudentId); // Assuming a list of payments
        Task<List<object>> ListStudentProducts(string jodoStudentId); // Assuming a list of products
        Task<ApiResponse> ManageFlexPlan(string jodoStudentId, ManageFlexPlanRequest request);
        Task<object> GetFlexSchedule(string jodoStudentId); // Assuming a schedule object
        Task<ApiResponse> RescheduleFlexInstallment(string jodoStudentId, RescheduleFlexInstallmentRequest request);
    }
}
