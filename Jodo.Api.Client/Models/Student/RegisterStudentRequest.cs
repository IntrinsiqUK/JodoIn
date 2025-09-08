using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.Student
{
    public class RegisterStudentRequest
    {
        [JsonProperty("student")]
        public StudentModel Student { get; set; }

        [JsonProperty("fee_components")]
        public List<FeeComponentModel> FeeComponents { get; set; }

        [JsonProperty("payments")]
        public List<object> Payments { get; set; } // Assuming payments are not detailed in the example
    }

    public class StudentModel
    {
        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("grade")]
        public string Grade { get; set; }

        [JsonProperty("new_admission")]
        public bool NewAdmission { get; set; }

        [JsonProperty("academic_year_start")]
        public string AcademicYearStart { get; set; }

        [JsonProperty("academic_year_end")]
        public string AcademicYearEnd { get; set; }

        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("primary_contact_name")]
        public string PrimaryContactName { get; set; }

        [JsonProperty("primary_contact_number")]
        public string PrimaryContactNumber { get; set; }

        [JsonProperty("primary_contact_email")]
        public string PrimaryContactEmail { get; set; }

        [JsonProperty("collector_code")]
        public string CollectorCode { get; set; }
    }

    public class FeeComponentModel
    {
        [JsonProperty("component_type")]
        public string ComponentType { get; set; }

        [JsonProperty("fee_amount")]
        public double FeeAmount { get; set; }
    }
}
