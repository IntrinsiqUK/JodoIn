using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Webhook
{
    [JsonConverter(typeof(WebhookEventCodeJsonConverter))]
    public enum WebhookEventCode
    {
        MasterdataStudentRegistered,
        MasterdataStudentDropped,
        MasterdataStudentActivated,
        CredLoanApplicationStarted,
        CredLoanApplicationFilled,
        CredLoanApplicationExpired,
        CredLoanFinalApproved,
        CredLoanRejected,
        CredLoanAgreementSigned,
        CredLoanDisbursed,
        CredLoanCanceled,
        CredEmiDebited,
        FlexSubscriptionSetup,
        FlexSubscriptionActive,
        FlexSubscriptionUpdated,
        FlexDownpaymentDebited,
        FlexDownpaymentSettled,
        FlexInstalmentDebited,
        FlexInstalmentSettled,
        FlexInstalmentBounced,
        FlexSubscriptionCancelled,
        FlexSubscriptionClosed,
        FlexMandateExpired,
        PayPaymentDebited,
        PayPaymentSettled,
        OrderPaymentDebited,
        OrderPaymentSettled,
        PaymentLinkPaymentExpired,
        PaymentLinkPaymentDebited,
        PaymentLinkPaymentSettled,
        PagePaymentDebited,
        PagePaymentSettled,
        DirectPaymentAdded,
        DirectPaymentCancelled,
        DirectPaymentUpdated
    }

    public sealed class WebhookEventCodeJsonConverter : JsonConverter<WebhookEventCode>
    {
        private static readonly Dictionary<string, WebhookEventCode> StringToEnum = new Dictionary<string, WebhookEventCode>(StringComparer.OrdinalIgnoreCase)
        {
            { "masterdata.student.registered", WebhookEventCode.MasterdataStudentRegistered },
            { "masterdata.student.dropped", WebhookEventCode.MasterdataStudentDropped },
            { "masterdata.student.activated", WebhookEventCode.MasterdataStudentActivated },
            { "cred.loan.application_started", WebhookEventCode.CredLoanApplicationStarted },
            { "cred.loan.application_filled", WebhookEventCode.CredLoanApplicationFilled },
            { "cred.loan.application_expired", WebhookEventCode.CredLoanApplicationExpired },
            { "cred.loan.final_approved", WebhookEventCode.CredLoanFinalApproved },
            { "cred.loan.rejected", WebhookEventCode.CredLoanRejected },
            { "cred.loan.agreement_signed", WebhookEventCode.CredLoanAgreementSigned },
            { "cred.loan.disbursed", WebhookEventCode.CredLoanDisbursed },
            { "cred.loan.canceled", WebhookEventCode.CredLoanCanceled },
            { "cred.emi.debited", WebhookEventCode.CredEmiDebited },
            { "flex.subscription.setup", WebhookEventCode.FlexSubscriptionSetup },
            { "flex.subscription.active", WebhookEventCode.FlexSubscriptionActive },
            { "flex.subscription.updated", WebhookEventCode.FlexSubscriptionUpdated },
            { "flex.downpayment.debited", WebhookEventCode.FlexDownpaymentDebited },
            { "flex.downpayment.settled", WebhookEventCode.FlexDownpaymentSettled },
            { "flex.instalment.debited", WebhookEventCode.FlexInstalmentDebited },
            { "flex.instalment.settled", WebhookEventCode.FlexInstalmentSettled },
            { "flex.instalment.bounced", WebhookEventCode.FlexInstalmentBounced },
            { "flex.subscription.cancelled", WebhookEventCode.FlexSubscriptionCancelled },
            { "flex.subscription.closed", WebhookEventCode.FlexSubscriptionClosed },
            { "flex.mandate.expired", WebhookEventCode.FlexMandateExpired },
            { "pay.payment.debited", WebhookEventCode.PayPaymentDebited },
            { "pay.payment.settled", WebhookEventCode.PayPaymentSettled },
            { "order.payment.debited", WebhookEventCode.OrderPaymentDebited },
            { "order.payment.settled", WebhookEventCode.OrderPaymentSettled },
            { "payment_link.payment.expired", WebhookEventCode.PaymentLinkPaymentExpired },
            { "payment_link.payment.debited", WebhookEventCode.PaymentLinkPaymentDebited },
            { "payment_link.payment.settled", WebhookEventCode.PaymentLinkPaymentSettled },
            { "page.payment.debited", WebhookEventCode.PagePaymentDebited },
            { "page.payment.settled", WebhookEventCode.PagePaymentSettled },
            { "direct.payment.added", WebhookEventCode.DirectPaymentAdded },
            { "direct.payment.cancelled", WebhookEventCode.DirectPaymentCancelled },
            { "direct.payment.updated", WebhookEventCode.DirectPaymentUpdated },
        };

        private static readonly Dictionary<WebhookEventCode, string> EnumToString = new Dictionary<WebhookEventCode, string>
        {
            { WebhookEventCode.MasterdataStudentRegistered, "masterdata.student.registered" },
            { WebhookEventCode.MasterdataStudentDropped, "masterdata.student.dropped" },
            { WebhookEventCode.MasterdataStudentActivated, "masterdata.student.activated" },
            { WebhookEventCode.CredLoanApplicationStarted, "cred.loan.application_started" },
            { WebhookEventCode.CredLoanApplicationFilled, "cred.loan.application_filled" },
            { WebhookEventCode.CredLoanApplicationExpired, "cred.loan.application_expired" },
            { WebhookEventCode.CredLoanFinalApproved, "cred.loan.final_approved" },
            { WebhookEventCode.CredLoanRejected, "cred.loan.rejected" },
            { WebhookEventCode.CredLoanAgreementSigned, "cred.loan.agreement_signed" },
            { WebhookEventCode.CredLoanDisbursed, "cred.loan.disbursed" },
            { WebhookEventCode.CredLoanCanceled, "cred.loan.canceled" },
            { WebhookEventCode.CredEmiDebited, "cred.emi.debited" },
            { WebhookEventCode.FlexSubscriptionSetup, "flex.subscription.setup" },
            { WebhookEventCode.FlexSubscriptionActive, "flex.subscription.active" },
            { WebhookEventCode.FlexSubscriptionUpdated, "flex.subscription.updated" },
            { WebhookEventCode.FlexDownpaymentDebited, "flex.downpayment.debited" },
            { WebhookEventCode.FlexDownpaymentSettled, "flex.downpayment.settled" },
            { WebhookEventCode.FlexInstalmentDebited, "flex.instalment.debited" },
            { WebhookEventCode.FlexInstalmentSettled, "flex.instalment.settled" },
            { WebhookEventCode.FlexInstalmentBounced, "flex.instalment.bounced" },
            { WebhookEventCode.FlexSubscriptionCancelled, "flex.subscription.cancelled" },
            { WebhookEventCode.FlexSubscriptionClosed, "flex.subscription.closed" },
            { WebhookEventCode.FlexMandateExpired, "flex.mandate.expired" },
            { WebhookEventCode.PayPaymentDebited, "pay.payment.debited" },
            { WebhookEventCode.PayPaymentSettled, "pay.payment.settled" },
            { WebhookEventCode.OrderPaymentDebited, "order.payment.debited" },
            { WebhookEventCode.OrderPaymentSettled, "order.payment.settled" },
            { WebhookEventCode.PaymentLinkPaymentExpired, "payment_link.payment.expired" },
            { WebhookEventCode.PaymentLinkPaymentDebited, "payment_link.payment.debited" },
            { WebhookEventCode.PaymentLinkPaymentSettled, "payment_link.payment.settled" },
            { WebhookEventCode.PagePaymentDebited, "page.payment.debited" },
            { WebhookEventCode.PagePaymentSettled, "page.payment.settled" },
            { WebhookEventCode.DirectPaymentAdded, "direct.payment.added" },
            { WebhookEventCode.DirectPaymentCancelled, "direct.payment.cancelled" },
            { WebhookEventCode.DirectPaymentUpdated, "direct.payment.updated" },
        };

        public override WebhookEventCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();
            if (s != null && StringToEnum.TryGetValue(s, out var value)) return value;
            throw new JsonException($"Unknown webhook event code: '{s}'");
        }

        public override void Write(Utf8JsonWriter writer, WebhookEventCode value, JsonSerializerOptions options)
        {
            if (!EnumToString.TryGetValue(value, out var s))
            {
                throw new JsonException($"Unknown webhook event code enum value: {value}");
            }
            writer.WriteStringValue(s);
        }
    }
}


