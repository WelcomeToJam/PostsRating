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
