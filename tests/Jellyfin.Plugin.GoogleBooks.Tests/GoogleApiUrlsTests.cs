using Jellyfin.Plugin.GoogleBooks.Common;

namespace Jellyfin.Plugin.GoogleBooks.Tests
{
    public class GoogleApiUrlsTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void AddApiKey_WithoutKey_ReturnsOriginalUrl(string? apiKey)
        {
            const string Url = "https://www.googleapis.com/books/v1/volumes?q=test";

            var result = GoogleApiUrls.AddApiKey(Url, apiKey);

            Assert.Equal(Url, result);
        }

        [Theory]
        [InlineData("https://www.googleapis.com/books/v1/volumes", "?")]
        [InlineData("https://www.googleapis.com/books/v1/volumes?q=test", "&")]
        public void AddApiKey_WithKey_AppendsEncodedKey(string url, string separator)
        {
            var result = GoogleApiUrls.AddApiKey(url, " test/key+value ");

            Assert.Equal(url + separator + "key=test%2Fkey%2Bvalue", result);
        }
    }
}
