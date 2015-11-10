using System.IO;
using System.Net;
using System.Text;

namespace PostsRating.Controller
{
    static class ResponseReader
    {
        public static string readResponseStream(HttpWebResponse response)
        {
            Stream stream = response.GetResponseStream();
            Encoding encode = Encoding.GetEncoding("utf-8");
            StreamReader reader = new StreamReader(stream, encode);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return responseFromServer;
        }
    }
}
