using PostsRating.Controller.Request.Builder;
using PostsRating.Model;
using System.Collections.Generic;

namespace PostsRating.Controller.Request.Sender
{
    // Класс для отправления запроса к vk api friends
    class FriendsRequest : ApiRequest
    {
        public FriendsRequest()
        {
            builder = new FriendRequestBuilder();
        }
        // Получить список друзей пользователя
        public List<string> getUsersFriends(User user)
        {
            return ResponseParser.parseResponse(response(builder.buildRequest(user.id)));
        }
    }
}
