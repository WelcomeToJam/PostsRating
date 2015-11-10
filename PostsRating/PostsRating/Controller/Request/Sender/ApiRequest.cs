using PostsRating.Controller.Request.Builder;
using System.Net;

namespace PostsRating.Controller.Request.Sender
{
    abstract class ApiRequest
    {
        protected RequestBuilder builder;
        // Возвращает ответ на запрос, переданный в requestPath, от сервера API 
        protected string response(string requestPath)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestPath);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return ResponseReader.readResponseStream(response);
        }
    }
}
