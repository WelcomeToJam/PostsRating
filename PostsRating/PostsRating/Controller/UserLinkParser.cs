using System.Text.RegularExpressions;

namespace PostsRating.Controller
{
    // Класс проверяющий корректность пользовательской ссылки 
    class UserLinkParser
    {
        private static string serverPattern = "^(https?:\\/\\/)?vk.com\\/";
        private static string idPattern = "^(https?:\\/\\/)?vk.com\\/id[1-9]{1}[0-9]{0,9}";
        private static string nickPattern = "^(https?:\\/\\/)?vk.com\\/[a-z]{1}[a-z0-9-_]{2,16}";

        // Метод, возвращающий true, если указан id пользователя.
        public static bool checkLinkForId(string linkToUser)
        {
            return Regex.IsMatch(linkToUser, idPattern, RegexOptions.IgnoreCase);
        }
        // Метод, возвращающий true, если указан nickname пользователя.
        public static bool checkLinkForNick(string linkToUser)
        {
            return Regex.IsMatch(linkToUser, nickPattern, RegexOptions.IgnoreCase);
        }
        // Метод, возвращающий значение id или nickname пользователя.
        // При отсутсвии совпадений возвращает пустую строку.
        public static string parseLink(string linkToUser)
        {
            if (checkLinkForId(linkToUser))
            {
                return Regex.Replace(linkToUser, serverPattern += "id", "");
            }
            if (checkLinkForNick(linkToUser))
            {
                return Regex.Replace(linkToUser, serverPattern, "");
            }
            return string.Empty;
        }
    }
}
