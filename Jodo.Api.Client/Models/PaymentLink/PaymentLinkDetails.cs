using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.PaymentLink
{
    public class PaymentLinkDetails
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        [JsonPropertyName("paid_at")]
        public DateTime? PaidAt { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("details")]
        public List<PaymentLinkDetailItem> Details { get; set; }
    }

    public class PaymentLinkDetailItem
    {
        [JsonPropertyName("component_type")]
        public string ComponentType { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("settlement_utr")]
        public string SettlementUtr { get; set; }

        [JsonPropertyName("settled_at")]
        public DateTime? SettledAt { get; set; }
    }
}


