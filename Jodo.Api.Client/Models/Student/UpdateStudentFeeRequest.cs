using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.Student
{
    public class UpdateStudentFeeRequest
    {
        [JsonProperty("fee_components")]
        public List<FeeComponentModel> FeeComponents { get; set; }
    }
}
