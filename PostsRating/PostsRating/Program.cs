using PostsRating.Controller;
using System;

namespace PostsRating
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Введите ссылку на пользователя: ");
            //string linkToUser = Console.ReadLine();
            //-------------------------------------------
            PostsRatingMaker top = new PostsRatingMaker();
            top.toRankPosts("60703958");
            Console.ReadKey();
        }
    }
}
