using System.Text.Json.Serialization;
using System;

namespace Jodo.Api.Client.Models.Student
{
    public class RescheduleFlexInstallmentRequest
    {
        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("new_due_date")]
        public DateTime NewDueDate { get; set; }
    }
}
