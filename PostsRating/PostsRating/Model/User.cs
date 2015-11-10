using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsRating.Model
{
    class User
    {
        public string id { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public List<User> friends { get; private set; }
        public List<Post> posts { get; private set; }

        public User(string id)
        {
            this.id = id;
            friends = new List<User>();
            posts = new List<Post>();
        }
        public void addFriend(string friendId)
        {
            friends.Add(new User(friendId));
        }
        public void addPost(string postId)
        {
            posts.Add(new Post(postId, id));
        }
    }

}
}
