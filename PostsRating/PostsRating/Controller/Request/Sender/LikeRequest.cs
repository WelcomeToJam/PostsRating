using PostsRating.Controller.Request.Builder;
using PostsRating.Model;

namespace PostsRating.Controller.Request.Sender
{
    // Класс для отправления запроса к vk api like
    class LikeRequest : ApiRequest
    {
        public LikeRequest()
        {
            builder = new LikeRequestBuilder();
        }
        // Получить список друзей пользователя
        public int getLikes(User user)
        {
            if (user != null)
            { 
                return ResponseParser.getNumberElements(response(builder.buildRequest(user)));
            }
            else
            {
                throw new System.NullReferenceException();
            }
        }
    }
}
