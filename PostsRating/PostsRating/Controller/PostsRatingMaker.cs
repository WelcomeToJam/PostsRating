using PostsRating.Controller.Request.Sender;
using PostsRating.Model;
using System;
using System.Collections.Generic;

namespace PostsRating.Controller
{
    // Основной класс программы, находящий самую популярную
    // (исходя из кол-ва лайков) запись.
    class PostsRatingMaker
    {
        private User           targetUser;
        private FriendsRequest vkFriends;
        private WallRequest    vkWall;
        private UserRequest    vkUser;
        private LikeRequest    vkLike;
        private Post           topPost;
        private int            timeToLive = (int)(DateTime.Now.AddDays(-7) - new DateTime(1970, 1, 1)).TotalSeconds;
        
        public PostsRatingMaker()
        {
            vkFriends = new FriendsRequest();
            vkWall    = new WallRequest();
            vkUser    = new UserRequest();
            vkLike    = new LikeRequest();
        }
        // Найти самую популярную запись
        public void findMostPopular(string linkToUser)
        {
            if(setUser(linkToUser))
            {
                setFriendsToUser();
                setPostsToUsersFriends();
                getLikesForPosts();
                find();
            }
            else
            {
                Console.WriteLine("Некорректная ссылка на пользователя.");
            }
        }
        public void printMostPopular()
        {
            Console.WriteLine("Самая популярная новость - " + topPost.id);
            Console.WriteLine("Владелец - " + topPost.ownerId);
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
        private bool setUser(string linkToUser)
        {
            try
            {
                string userValue = UserLinkParser.parseLink(linkToUser);
                if (char.IsDigit(userValue, 0))
                {
                    targetUser = new User(userValue);
                    return true;
                }
                User usr = new User(userValue);
                if (usr != null)
                {
                    string id = vkUser.getUser(usr).ToString();
                    targetUser = new User(id);
                }
                else
                {
                    return false;
                }
                if (targetUser == null)
                {
                    return false;
                }
                else return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private void getLikesForPosts()
        {
            if (targetUser.friends != null && targetUser.friends.Count > 0)
            {
                foreach (User friend in targetUser.friends)
                {
                    if (friend.posts != null && friend.posts.Count > 0)
                    {
                        foreach (Post post in friend.posts)
                        {
                            post.likesCount = vkLike.getLikes(friend);
                        }
                    }
                } // foreach (User friend)
            } // if (userList)
        }
        private void find()
        {
            int tempLikeCount = 0;
            string pId = string.Empty, uId = string.Empty;
            foreach (User usr in targetUser.friends)
            {
                foreach (Post post in usr.posts)
                {
                    if (post.likesCount > tempLikeCount)
                    {
                        tempLikeCount = post.likesCount;
                        uId = usr.id;
                        pId = post.id;
                    }
                }
            }
            topPost = new Post(pId, uId);
        }
    }
}
