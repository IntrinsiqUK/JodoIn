using Jodo.Api.Client.Models.Shared;
using Jodo.Api.Client.Models.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<RegisterStudentResponse> RegisterStudent(string registrationId, RegisterStudentRequest request)
        {
            return Post<RegisterStudentRequest, RegisterStudentResponse>($"api/v1/integrations/erp/users/{registrationId}/students", request);
        }

        public Task<ApiResponse> UpdateStudent(string jodoStudentId, UpdateStudentRequest request)
        {
            return Patch<UpdateStudentRequest, ApiResponse>($"api/v1/integrations/erp/students/{jodoStudentId}", request);
        }

        public Task<ApiResponse> UpdateStudentFee(string jodoStudentId, UpdateStudentFeeRequest request)
        {
            return Patch<UpdateStudentFeeRequest, ApiResponse>($"api/v1/integrations/erp/students/{jodoStudentId}/fee", request);
        }

        public Task<GetStudentDetailsResponse> GetStudentDetails(string jodoStudentId)
        {
            return Get<GetStudentDetailsResponse>($"api/v1/integrations/erp/students/{jodoStudentId}");
        }

        public Task<ApiResponse> PostPayment(string jodoStudentId, PostPaymentRequest request)
        {
            return Post<PostPaymentRequest, ApiResponse>($"api/v1/integrations/erp/students/{jodoStudentId}/payments", request);
        }

        public Task CancelPayment(string jodoStudentId, string transactionId)
        {
            return Delete($"api/v1/integrations/erp/students/{jodoStudentId}/payments/{transactionId}");
        }

        public Task<List<object>> ListStudentPayments(string jodoStudentId)
        {
            return Get<List<object>>($"api/v1/integrations/erp/students/{jodoStudentId}/payments");
        }

        public Task<List<object>> ListStudentProducts(string jodoStudentId)
        {
            return Get<List<object>>($"api/v1/integrations/erp/students/{jodoStudentId}/products");
        }

        public Task<ApiResponse> ManageFlexPlan(string jodoStudentId, ManageFlexPlanRequest request)
        {
            return Post<ManageFlexPlanRequest, ApiResponse>($"api/v1/integrations/flex/students/{jodoStudentId}/plans", request);
        }

        public Task<object> GetFlexSchedule(string jodoStudentId)
        {
            return Get<object>($"api/v1/integrations/flex/students/{jodoStudentId}/plans");
        }

        public Task<ApiResponse> RescheduleFlexInstallment(string jodoStudentId, RescheduleFlexInstallmentRequest request)
        {
            return Patch<RescheduleFlexInstallmentRequest, ApiResponse>($"api/v1/integrations/flex/students/{jodoStudentId}/reschedule", request);
        }
    }
}
