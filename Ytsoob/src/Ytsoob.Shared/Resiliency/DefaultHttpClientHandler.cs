using System.Net;

namespace Ytsoob.Shared.Resiliency;

public class DefaultHttpClientHandler : HttpClientHandler
{
    public DefaultHttpClientHandler() =>
        AutomaticDecompression = DecompressionMethods.Brotli | DecompressionMethods.Deflate | DecompressionMethods.GZip;
}
