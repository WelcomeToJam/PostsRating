namespace PostsRating.Controller.Request.Builder
{
    class WallRequestBuilder : RequestBuilder
    {
        public WallRequestBuilder() : base()
        {
            methodName = "wall.get?";
        }
        public override string buildRequest(string userId)
        {
            return (serverName.Append(methodName).Append("owner_id=").Append(userId)).ToString();
        }
    }
}
