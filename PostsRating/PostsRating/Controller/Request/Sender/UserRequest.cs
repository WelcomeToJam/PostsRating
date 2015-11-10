using PostsRating.Controller.Request.Builder;
using System.Collections.Generic;

namespace PostsRating.Controller.Request.Sender
{
    class UserRequest : ApiRequest
    {
        public UserRequest() { builder = new UserRequestBuilder(); }
        // Получить информация о пользователе по ссылке 
        public List<string> getUser(string linkToUser)
        {
            return ResponseParser.parseResponse(response(builder.buildRequest(linkToUser)));
        }
    }
}
