namespace PostsRating.Controller.Request.Builder
{
    class UserRequestBuilder : RequestBuilder
    {
        public UserRequestBuilder() : base()
        {
            methodName = "users.get?";
        }
        public override string buildRequest(string linkToUser)
        {
            request = string.Empty;
            return request = serverName + methodName + "user_ids=" + linkToUser;
        }
    }
}
