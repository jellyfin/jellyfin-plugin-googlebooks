using System.Net;

namespace Jellyfin.Plugin.GoogleBooks.Tests.Http
{
    internal record MockHttpResponse(HttpStatusCode StatusCode, string Response);
}
