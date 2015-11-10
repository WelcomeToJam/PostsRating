using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsRating.Model
{
    class Post
    {
        public string ownerId { get; private set; }
        public string id      { get; private set; }
        public int likesCount { get; private set; }
        public Post(string id, string ownerId)
        {
            this.id = id;
            this.ownerId = ownerId;
        }
    }
}
