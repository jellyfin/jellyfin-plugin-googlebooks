using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.GoogleBooks
{
    /// <inheritdoc/>
    public class PluginConfiguration : BasePluginConfiguration
    {
        /// <summary>
        /// Gets or sets the Google Books API key.
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;
    }
}
