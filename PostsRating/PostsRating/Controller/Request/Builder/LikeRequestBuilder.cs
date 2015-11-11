namespace PostsRating.Controller.Request.Builder
{
    // Класс, составляющий запрос к vk api like
    class LikeRequestBuilder : RequestBuilder
    {
        public LikeRequestBuilder() : base()
        {
            methodName = "likes.getList?";
        }
        public override string buildRequest(string userId)
        {
            request = string.Empty;
            return request = serverName + methodName + "user_id=" + userId;
        }
    }
}
