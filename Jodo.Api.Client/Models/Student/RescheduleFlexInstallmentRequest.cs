using Newtonsoft.Json;
using System;

namespace Jodo.Api.Client.Models.Student
{
    public class RescheduleFlexInstallmentRequest
    {
        [JsonProperty("due_date")]
        public DateTime DueDate { get; set; }

        [JsonProperty("new_due_date")]
        public DateTime NewDueDate { get; set; }
    }
}
