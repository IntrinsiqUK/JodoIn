using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Student
{
    public class RegisterStudentResponse
    {
        [JsonPropertyName("jodo_student_id")]
        public string JodoStudentId { get; set; }
    }
}
