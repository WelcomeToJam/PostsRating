﻿using PostsRating.Controller.Request.Builder;
using PostsRating.Model;
using System.Collections.Generic;

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
        public List<string> getLikes(User user)
        {
            return ResponseParser.parseResponse(response(builder.buildRequest(user.id)));
        }
    }
}
