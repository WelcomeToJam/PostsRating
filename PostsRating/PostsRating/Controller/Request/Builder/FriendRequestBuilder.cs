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
            request = string.Empty;
            return request = serverName + methodName + "user_id=" + userId; 
        }
    }
}