using Newtonsoft.Json;

namespace Jodo.Api.Client.Models.Student
{
    public class UpdateStudentRequest
    {
        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("custom_identifier")]
        public string CustomIdentifier { get; set; }

        [JsonProperty("grade_label")]
        public string GradeLabel { get; set; }

        [JsonProperty("primary_contact_name")]
        public string PrimaryContactName { get; set; }

        [JsonProperty("primary_contact_number")]
        public string PrimaryContactNumber { get; set; }

        [JsonProperty("primary_contact_email")]
        public string PrimaryContactEmail { get; set; }

        [JsonProperty("secondary_contact_name")]
        public string SecondaryContactName { get; set; }

        [JsonProperty("secondary_contact_number")]
        public string SecondaryContactNumber { get; set; }

        [JsonProperty("secondary_contact_email")]
        public string SecondaryContactEmail { get; set; }
    }
}
