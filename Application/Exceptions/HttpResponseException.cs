using System.Net;

namespace MapMyJourneyAPI.Application.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage;

        public HttpResponseException(HttpStatusCode statusCode, string message) => (StatusCode, ErrorMessage) = (statusCode, message);
    }
}