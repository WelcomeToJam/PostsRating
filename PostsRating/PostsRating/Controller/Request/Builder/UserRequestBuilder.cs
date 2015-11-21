using PostsRating.Model;

namespace PostsRating.Controller.Request.Builder
{
    // Класс, составляющий запрос к vk api user
    class UserRequestBuilder : RequestBuilder
    {
        public UserRequestBuilder() : base()
        {
            methodName = "users.get?";
        }
        public override string buildRequest(User user)
        {
            request = string.Empty;
            return request = serverName + methodName + "user_ids=" + user.id;
        }
    }
}
