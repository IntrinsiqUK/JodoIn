using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.PaymentLink
{
    /// <summary>
    /// Request to create a payment link.
    /// </summary>
    /// <remarks>
    /// Required fields: name, phone, email, details[].component_type, details[].amount.
    /// Optional fields: student_name, grade, date_of_birth, identifier, new_admission,
    /// custom_identifier, academic_year_start, academic_year_end, expires_at, notes.
    /// </remarks>
    public class CreatePaymentLinkRequest
    {
        /// <summary>Expiry date/time (ISO 8601). Optional.</summary>
        [JsonPropertyName("expires_at")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ExpiresAt { get; set; }

        /// <summary>Name of the customer. Required.</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>Phone number of the customer. Required.</summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>Email of the customer. Required.</summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>Name of the student. Optional.</summary>
        [JsonPropertyName("student_name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StudentName { get; set; }

        /// <summary>Unique Grade Identifier. Optional.</summary>
        [JsonPropertyName("grade")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Grade { get; set; }

        /// <summary>Date of birth. Optional.</summary>
        [JsonPropertyName("date_of_birth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DateOfBirth { get; set; }

        /// <summary>Student Identifier assigned by the school. Optional.</summary>
        [JsonPropertyName("identifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Identifier { get; set; }

        /// <summary>Flag to indicate if the student is a new admission. Optional.</summary>
        [JsonPropertyName("new_admission")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NewAdmission { get; set; }

        /// <summary>Student Custom Identifier. Optional.</summary>
        [JsonPropertyName("custom_identifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CustomIdentifier { get; set; }

        /// <summary>Starting Year of the Academic Year. Optional.</summary>
        [JsonPropertyName("academic_year_start")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? AcademicYearStart { get; set; }

        /// <summary>Ending Year of the Academic Year. Optional.</summary>
        [JsonPropertyName("academic_year_end")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? AcademicYearEnd { get; set; }

        /// <summary>List of fee details. Required (at least one).</summary>
        [JsonPropertyName("details")]
        public List<PaymentLinkDetail> Details { get; set; }

        /// <summary>Optional notes (key/value pairs).</summary>
        [JsonPropertyName("notes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Note> Notes { get; set; }
    }

    public class PaymentLinkDetail
    {
        /// <summary>Payment detail type. Required.</summary>
        [JsonPropertyName("component_type")]
        public string ComponentType { get; set; }

        /// <summary>Amount to be collected. Required, must be > 0.</summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }

    public class Note
    {
        /// <summary>Note key.</summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>Note value.</summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
