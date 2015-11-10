namespace PostsRating.Controller.RequestBuilder
{
    class LikeRequestBuilder : RequestBuilder
    {
        public LikeRequestBuilder() : base()
        {
            methodName = "likes.getList?";
        }
        public override string buildRequest(string userId)
        {
            return (serverName.Append(methodName).Append("user_id=").Append(userId)).ToString();
        }
    }
}
