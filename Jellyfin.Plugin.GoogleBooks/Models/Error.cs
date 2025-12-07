using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Jellyfin.Plugin.GoogleBooks.Models
{
    internal class Error
    {
        public HttpStatusCode Code { get; set; }

        public string Message { get; set; } = string.Empty;

        public IEnumerable<ErrorDetails> Errors { get; set; } = Enumerable.Empty<ErrorDetails>();
    }
}
