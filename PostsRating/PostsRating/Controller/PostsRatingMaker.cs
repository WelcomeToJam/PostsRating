using PostsRating.Controller.Request.Sender;
using PostsRating.Model;
using System;
using System.Collections.Generic;

namespace PostsRating.Controller
{
    class PostsRating
    {
        private User targetUser;
        private FriendsRequest vkFriends;
        private WallRequest vkWall;
        private UserRequest vkUser;
        private List<Post> topPosts;
        private int timeToLive = (int)(DateTime.Now.AddDays(-7) - new DateTime(1970, 1, 1)).TotalSeconds;

        public PostsRating()
        {
            vkFriends = new FriendsRequest();
            vkWall    = new WallRequest();
            vkUser    = new UserRequest();
        }
        // Составить рейтинг из 10 самых популярных записей
        public void toRankPosts(string linkToUser)
        {
            targetUser = new User(linkToUser);
            if (targetUser == null) { return; }
            setFriendsToUser();
            setPostsToUsersFriends();
        }
        // Получить список друзей для целевого пользователя
        private void setFriendsToUser()
        {
            List<string> friendsList = vkFriends.getUsersFriends(targetUser);
            if (friendsList.Count > 0)
            {
                foreach (string friend in friendsList)
                {
                    targetUser.addFriend(friend);
                }
            }
        }
        //  Получить список записей за прошедшую неделю для каждого пользователя в списке друзей
        private void setPostsToUsersFriends()
        {
            List<User> usersList = targetUser.friends;
            if (usersList != null && usersList.Count > 0)
            {
                List<string> postsList;
                foreach (User friend in usersList)
                {
                    postsList = vkWall.getFriendsPosts(friend, timeToLive);
                    if (postsList != null && postsList.Count > 0)
                    {
                        foreach (string id in postsList)
                        {
                            friend.addPost(id);
                        }
                    }
                } // foreach (User friend)
            } // if (userList)
        }
        private void getLikesForPosts()
        {

        }
    }
}
