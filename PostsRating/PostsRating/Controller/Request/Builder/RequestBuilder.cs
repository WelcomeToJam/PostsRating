namespace PostsRating.Controller.Request.Builder
{
    abstract class RequestBuilder
    {
        protected string serverName { get; set; }
        protected string methodName { get; set; }
        protected string request { get; set; }

        protected RequestBuilder()
        {
            serverName = "https://api.vk.com/method/";
        }
        abstract public string buildRequest(string userId);
    }
}