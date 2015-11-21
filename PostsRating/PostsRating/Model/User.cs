using System.Collections.Generic;
using System;

namespace PostsRating.Model
{
    class User
    {
        public string id { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public List<User> friends { get; private set; }
        public List<Post> posts { get; private set; }
        public int counter;
        public User(string id)
        {
            this.id = id;
            friends = new List<User>();
            posts = new List<Post>();
            counter = -1;
        }
        public void addFriend(string friendId)
        {
            friends.Add(new User(friendId));
        }
        public void addPost(string postId)
        {
            posts.Add(new Post(postId, id));
        }
        public Post getNextPost()
        {
            try
            {
                if (posts.Count > counter)
                {
                    return posts[++counter];
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

