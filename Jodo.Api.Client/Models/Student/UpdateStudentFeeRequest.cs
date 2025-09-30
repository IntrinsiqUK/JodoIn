using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.Student
{
    public class UpdateStudentFeeRequest
    {
        [JsonPropertyName("fee_components")]
        public List<FeeComponentModel> FeeComponents { get; set; }
    }
}
