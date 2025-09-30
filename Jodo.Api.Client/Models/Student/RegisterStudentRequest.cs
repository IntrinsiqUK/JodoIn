using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.Student
{
    public class RegisterStudentRequest
    {
        [JsonPropertyName("student")]
        public StudentModel Student { get; set; }

        [JsonPropertyName("fee_components")]
        public List<FeeComponentModel> FeeComponents { get; set; }

        [JsonPropertyName("payments")]
        public List<object> Payments { get; set; } // Assuming payments are not detailed in the example
    }

    public class StudentModel
    {
        [JsonPropertyName("fullname")]
        public string Fullname { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("grade")]
        public string Grade { get; set; }

        [JsonPropertyName("new_admission")]
        public bool NewAdmission { get; set; }

        [JsonPropertyName("academic_year_start")]
        public string AcademicYearStart { get; set; }

        [JsonPropertyName("academic_year_end")]
        public string AcademicYearEnd { get; set; }

        [JsonPropertyName("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("primary_contact_name")]
        public string PrimaryContactName { get; set; }

        [JsonPropertyName("primary_contact_number")]
        public string PrimaryContactNumber { get; set; }

        [JsonPropertyName("primary_contact_email")]
        public string PrimaryContactEmail { get; set; }

        [JsonPropertyName("collector_code")]
        public string CollectorCode { get; set; }
    }

    public class FeeComponentModel
    {
        [JsonPropertyName("component_type")]
        public string ComponentType { get; set; }

        [JsonPropertyName("fee_amount")]
        public double FeeAmount { get; set; }
    }
}
