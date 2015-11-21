using PostsRating.Controller.Request.Builder;
using PostsRating.Model;
using System.Collections.Generic;

namespace PostsRating.Controller.Request.Sender
{
    // Класс для отправления запроса к vk api user
    class UserRequest : ApiRequest
    {
        public UserRequest() { builder = new UserRequestBuilder(); }
        // Получить информация о пользователе по ссылке 
        public List<string> getUser(User user)
        {
            return ResponseParser.parseResponse(response(builder.buildRequest(user)));
        }
    }
}
