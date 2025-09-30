using System;

namespace Jodo.Api.Client.Internal
{
    public static class HttpTrace
    {
        public static event Action<string, string> RequestLogged;
        public static event Action<string, string> ResponseLogged;

        public static void LogRequest(string requestLine, string requestBody)
        {
            RequestLogged?.Invoke(requestLine, requestBody ?? string.Empty);
        }

        public static void LogResponse(string responseStatus, string responseBody)
        {
            ResponseLogged?.Invoke(responseStatus, responseBody ?? string.Empty);
        }
    }
}


