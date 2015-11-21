using PostsRating.Model;

namespace PostsRating.Controller.Request.Builder
{
    // Абстрактный класс, составляющий запрос к vk api
    abstract class RequestBuilder
    {
        protected string serverName { get; set; }
        protected string methodName { get; set; }
        protected string request { get; set; }

        protected RequestBuilder()
        {
            serverName = "https://api.vk.com/method/";
        }
        abstract public string buildRequest(User user);
    }
}