namespace Jodo.Api.Client.Tests
{
    public static class TestHttpTrace
    {
        public static string LastRequest { get; set; } = string.Empty;
        public static string LastRequestBody { get; set; } = string.Empty;
        public static string LastResponseStatus { get; set; } = string.Empty;
        public static string LastResponseBody { get; set; } = string.Empty;
    }
}


