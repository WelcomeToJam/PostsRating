namespace PostsRating.Controller.Request.Builder
{
    // Класс, составляющий запрос к vk api wall
    class WallRequestBuilder : RequestBuilder
    {
        public WallRequestBuilder() : base()
        {
            methodName = "wall.get?";
        }
        public override string buildRequest(string userId)
        {
            request = string.Empty;
            return request = serverName + methodName + "owner_id=" + userId;
        }
    }
}
