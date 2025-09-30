using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.Student
{
    public class ManageFlexPlanRequest
    {
        [JsonPropertyName("payment_schedule")]
        public List<PaymentSchedule> PaymentSchedule { get; set; }
    }

    public class PaymentSchedule
    {
        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("details")]
        public List<PaymentDetail> Details { get; set; }
    }

    public class PaymentDetail
    {
        [JsonPropertyName("component_type")]
        public string ComponentType { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}
