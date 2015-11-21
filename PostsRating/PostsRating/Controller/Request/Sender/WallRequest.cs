using PostsRating.Controller.Request.Builder;
using PostsRating.Model;
using System.Collections.Generic;

namespace PostsRating.Controller.Request.Sender
{
    // Класс для отправления запроса к vk api wall
    class WallRequest : ApiRequest
    {
        public WallRequest() { builder = new WallRequestBuilder(); }
        // Получить список новостей друзей пользователя
        public List<string> getFriendsPosts(User user, int timeToLive)
        {
            return ResponseParser.parseResponse(response(builder.buildRequest(user)), timeToLive);
        }
    }
}
