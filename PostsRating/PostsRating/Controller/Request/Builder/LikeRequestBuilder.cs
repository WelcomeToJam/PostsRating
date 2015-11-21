using PostsRating.Model;

namespace PostsRating.Controller.Request.Builder
{
    // Класс, составляющий запрос к vk api like
    class LikeRequestBuilder : RequestBuilder
    {
        public LikeRequestBuilder() : base()
        {
            methodName = "likes.getList?";
        }
        public override string buildRequest(User user)
        {
            request = string.Empty;
            if (user != null)
            {
                return request = serverName + methodName + "type=post" + "&owner_id=" + user.id +
                    "&item_id=" + user.getNextPost().id + "&filter=likes";
            }
            else
            {
                throw new System.NullReferenceException();
            }
        }
    }
}

