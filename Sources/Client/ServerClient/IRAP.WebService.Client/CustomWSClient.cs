using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace IRAP.WebService.Client
{
    public class CustomWSClient
    {
        protected string EncodingParam(string inputString)
        {
            byte[] gzipBuffer;

            using (MemoryStream compressed = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(compressed, CompressionMode.Compress))
                {
                    using (MemoryStream reader = new MemoryStream(Encoding.UTF8.GetBytes(inputString)))
                    {
                        reader.CopyTo(gzip);
                    }
                }

                gzipBuffer = compressed.ToArray();
            }

            return Convert.ToBase64String(gzipBuffer);
        }

        protected string DecodingParam(string outputString)
        {
            byte[] compressed;
            byte[] decoded;

            compressed = Convert.FromBase64String(outputString);
            using (MemoryStream reader = new MemoryStream(compressed))
            {
                using (GZipStream gzip = new GZipStream(reader, CompressionMode.Decompress))
                {
                    using (MemoryStream uncompressed = new MemoryStream())
                    {
                        gzip.CopyTo(uncompressed);
                        decoded = uncompressed.ToArray();
                    }
                }
            }

            return Encoding.UTF8.GetString(decoded);
        }
    }
}
