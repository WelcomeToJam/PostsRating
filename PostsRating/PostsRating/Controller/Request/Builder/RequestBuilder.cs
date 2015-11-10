using System.Text;

namespace PostsRating.Controller.Request.Builder
{
    abstract class RequestBuilder
    {
        protected StringBuilder serverName { get; set; }
        protected string methodName { get; set; }

        protected RequestBuilder()
        {
            serverName = new StringBuilder("https://api.vk.com/method/");
        }
        abstract public string buildRequest(string userId);
    }
}
