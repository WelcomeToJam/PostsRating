using PostsRating.Model;

namespace PostsRating.Controller.Request.Builder
{
    // Класс, составляющий запрос к vk api friend
    class FriendRequestBuilder : RequestBuilder
    {
        public FriendRequestBuilder() : base()
        {
            methodName = "friends.get?";
        }
        public override string buildRequest(User user)
        {
            request = string.Empty;
            return request = serverName + methodName + "user_id=" + user.id; 
        }
    }
}