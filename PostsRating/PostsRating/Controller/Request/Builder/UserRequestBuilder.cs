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
            return (serverName.Append(methodName).Append("user_ids=").Append(linkToUser)).ToString();
        }
    }
}
