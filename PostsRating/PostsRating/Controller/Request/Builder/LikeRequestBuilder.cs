namespace PostsRating.Controller.Request.Builder
{
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
