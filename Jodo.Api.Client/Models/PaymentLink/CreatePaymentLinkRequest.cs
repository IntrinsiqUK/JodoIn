using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.PaymentLink
{
    public class CreatePaymentLinkRequest
    {
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("student_name")]
        public string StudentName { get; set; }

        [JsonProperty("grade")]
        public string Grade { get; set; }

        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("new_admission")]
        public bool NewAdmission { get; set; }

        [JsonProperty("custom_identifier")]
        public string CustomIdentifier { get; set; }

        [JsonProperty("academic_year_start")]
        public int AcademicYearStart { get; set; }

        [JsonProperty("academic_year_end")]
        public int AcademicYearEnd { get; set; }

        [JsonProperty("details")]
        public List<PaymentLinkDetail> Details { get; set; }

        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }
    }

    public class PaymentLinkDetail
    {
        [JsonProperty("component_type")]
        public string ComponentType { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }

    public class Note
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
