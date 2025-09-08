using System;
using System.Net;

namespace Jodo.Api.Client.Exceptions
{
    public class JodoApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string Content { get; }

        public JodoApiException(HttpStatusCode statusCode, string content)
            : base($"Jodo API request failed with status code {statusCode}: {content}")
        {
            StatusCode = statusCode;
            Content = content;
        }
    }
}
