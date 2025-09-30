using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Student
{
    public class UpdateStudentRequest
    {
        [JsonPropertyName("fullname")]
        public string Fullname { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("custom_identifier")]
        public string CustomIdentifier { get; set; }

        [JsonPropertyName("grade_label")]
        public string GradeLabel { get; set; }

        [JsonPropertyName("primary_contact_name")]
        public string PrimaryContactName { get; set; }

        [JsonPropertyName("primary_contact_number")]
        public string PrimaryContactNumber { get; set; }

        [JsonPropertyName("primary_contact_email")]
        public string PrimaryContactEmail { get; set; }

        [JsonPropertyName("secondary_contact_name")]
        public string SecondaryContactName { get; set; }

        [JsonPropertyName("secondary_contact_number")]
        public string SecondaryContactNumber { get; set; }

        [JsonPropertyName("secondary_contact_email")]
        public string SecondaryContactEmail { get; set; }
    }
}
