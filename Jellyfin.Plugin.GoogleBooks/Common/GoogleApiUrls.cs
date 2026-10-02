using System;

namespace Jellyfin.Plugin.GoogleBooks.Common
{
    /// <summary>
    /// Google API urls.
    /// </summary>
    public static class GoogleApiUrls
    {
        /// <summary>
        /// Gets the search url.
        /// </summary>
        public const string SearchUrl = @"https://www.googleapis.com/books/v1/volumes?q={0}&startIndex={1}&maxResults={2}";

        /// <summary>
        /// Gets the details url.
        /// </summary>
        public const string DetailsUrl = @"https://www.googleapis.com/books/v1/volumes/{0}";

        /// <summary>
        /// Adds the configured API key to a Google Books API URL.
        /// </summary>
        /// <param name="url">The Google Books API URL.</param>
        /// <param name="apiKey">The optional API key.</param>
        /// <returns>The URL with the API key, when configured.</returns>
        public static string AddApiKey(string url, string? apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return url;
            }

            var separator = url.Contains('?', StringComparison.Ordinal) ? '&' : '?';
            return string.Concat(url, separator, "key=", Uri.EscapeDataString(apiKey.Trim()));
        }
    }
}
