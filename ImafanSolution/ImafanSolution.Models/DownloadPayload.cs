using System.IO;

namespace ImafanSolution.Models
{
    public class DownloadPayload
    {
        public Stream Stream { get; set; }

        public string ContentType { get; set; }
    }
}