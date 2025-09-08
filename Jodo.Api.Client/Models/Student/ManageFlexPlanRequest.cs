using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.Student
{
    public class ManageFlexPlanRequest
    {
        [JsonProperty("payment_schedule")]
        public List<PaymentSchedule> PaymentSchedule { get; set; }
    }

    public class PaymentSchedule
    {
        [JsonProperty("due_date")]
        public DateTime DueDate { get; set; }

        [JsonProperty("details")]
        public List<PaymentDetail> Details { get; set; }
    }

    public class PaymentDetail
    {
        [JsonProperty("component_type")]
        public string ComponentType { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
