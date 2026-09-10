using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Jellyfin.Extensions.Json;
using Jellyfin.Plugin.GoogleBooks.Common;
using Jellyfin.Plugin.GoogleBooks.Models;
using MediaBrowser.Common.Net;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.GoogleBooks.Providers
{
    /// <summary>
    /// Base class for the Google Books providers.
    /// </summary>
    public abstract class BaseGoogleBooksProvider
    {
        private readonly ILogger<BaseGoogleBooksProvider> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Func<string?> _apiKeyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGoogleBooksProvider"/> class.
        /// </summary>
        /// <param name="logger">Instance of the <see cref="ILogger{GoogleBooksProvider}"/> interface.</param>
        /// <param name="httpClientFactory">Instance of the <see cref="IHttpClientFactory"/> interface.</param>
        /// <param name="apiKeyProvider">Function that returns the configured Google Books API key.</param>
        protected BaseGoogleBooksProvider(
            ILogger<BaseGoogleBooksProvider> logger,
            IHttpClientFactory httpClientFactory,
            Func<string?>? apiKeyProvider = null)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _apiKeyProvider = apiKeyProvider ?? (() => Plugin.Instance?.Configuration.ApiKey);
        }

        /// <summary>
        /// Get a result from the Google Books API.
        /// </summary>
        /// <typeparam name="T">Type of expected result.</typeparam>
        /// <param name="url">API URL to call.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The API result.</returns>
        protected async Task<T?> GetResultFromAPI<T>(string url, CancellationToken cancellationToken)
            where T : class
        {
            var requestUrl = GoogleApiUrls.AddApiKey(url, _apiKeyProvider());
            var response = await _httpClientFactory
                .CreateClient(NamedClient.Default)
                .GetAsync(requestUrl, cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>(JsonDefaults.Options, cancellationToken).ConfigureAwait(false);

                if (errorResponse != null)
                {
                    _logger.LogError("Error response from Google Books API: {ErrorMessage} (status code: {StatusCode})", errorResponse.Error.Message, response.StatusCode);
                }

                return null;
            }

            return await response.Content.ReadFromJsonAsync<T>(JsonDefaults.Options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch book data from the Google Books API.
        /// </summary>
        /// <param name="googleBookId">The volume id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The API result.</returns>
        protected async Task<BookResult?> FetchBookData(string googleBookId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var url = string.Format(CultureInfo.InvariantCulture, GoogleApiUrls.DetailsUrl, googleBookId);

            return await GetResultFromAPI<BookResult>(url, cancellationToken).ConfigureAwait(false);
        }
    }
}
