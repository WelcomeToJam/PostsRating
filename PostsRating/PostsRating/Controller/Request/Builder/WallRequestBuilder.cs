using PostsRating.Model;

namespace PostsRating.Controller.Request.Builder
{
    // Класс, составляющий запрос к vk api wall
    class WallRequestBuilder : RequestBuilder
    {
        public WallRequestBuilder() : base()
        {
            methodName = "wall.get?";
        }
        public override string buildRequest(User user)
        {
            request = string.Empty;
            return request = serverName + methodName + "owner_id=" + user.id + "&filter=all";
        }
    }
}
