using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.Student
{
    public class PostPaymentRequest
    {
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("paid_at")]
        public DateTime PaidAt { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        [JsonPropertyName("fee_components")]
        public List<PaymentFeeComponentModel> FeeComponents { get; set; }
    }

    public class PaymentFeeComponentModel
    {
        [JsonPropertyName("component_type")]
        public string ComponentType { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}
