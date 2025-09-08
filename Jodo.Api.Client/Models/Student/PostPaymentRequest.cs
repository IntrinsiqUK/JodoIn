using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.Student
{
    public class PostPaymentRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("paid_at")]
        public DateTime PaidAt { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("fee_components")]
        public List<PaymentFeeComponentModel> FeeComponents { get; set; }
    }

    public class PaymentFeeComponentModel
    {
        [JsonProperty("component_type")]
        public string ComponentType { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
