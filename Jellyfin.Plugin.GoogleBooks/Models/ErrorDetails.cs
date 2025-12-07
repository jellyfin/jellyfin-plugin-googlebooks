namespace Jellyfin.Plugin.GoogleBooks.Models
{
    internal class ErrorDetails
    {
        public string Message { get; set; } = string.Empty;

        public string Domain { get; set; } = string.Empty;

        public string Reason { get; set; } = string.Empty;
    }
}
