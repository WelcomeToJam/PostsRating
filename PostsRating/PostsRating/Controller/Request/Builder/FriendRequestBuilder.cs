namespace PostsRating.Controller.Request.Builder
{
    class FriendRequestBuilder : RequestBuilder
    {
        public FriendRequestBuilder() : base()
        {
            methodName = "friends.get?";
        }
        public override string buildRequest(string userId)
        {
            return (serverName.Append(methodName).Append("user_id=").Append(userId)).ToString();
        }
    }
}
