using PostsRating.Controller.Request.Builder;
using PostsRating.Model;
using System.Collections.Generic;

namespace PostsRating.Controller.Request.Sender
{
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
