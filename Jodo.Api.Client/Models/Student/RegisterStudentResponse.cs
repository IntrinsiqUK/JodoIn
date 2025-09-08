using Newtonsoft.Json;

namespace Jodo.Api.Client.Models.Student
{
    public class RegisterStudentResponse
    {
        [JsonProperty("jodo_student_id")]
        public string JodoStudentId { get; set; }
    }
}
