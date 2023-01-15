namespace AnonTalkAPI
{
    public static class Constants
    {
        public static class Board
        {
            public const int MaxPostsOnBoard = 300;
        }
        public static class Post
        {
            public const int HideCommentsLimit = 3;
            public const string PostImagePath = "StaticFiles/images/posts/";
            public const string PostImageExt = ".png";
        }
        public static class Comment
        {
            public const string CommentImagePath = "StaticFiles/images/comments/";
            public const string CommentImageExt = ".png";
        }
    }
}
