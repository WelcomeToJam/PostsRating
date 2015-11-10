using System.Text.RegularExpressions;

namespace PostsRating.Controller
{
    class UserLinkParser
    {

        private static string serverPattern = "^(https?:\\/\\/)?vk.com\\/";
        private static string idPattern = "^(https?:\\/\\/)?vk.com\\/id[1-9]{1}[0-9]{0,9}";
        private static string nickPattern = "^(https?:\\/\\/)?vk.com\\/[a-z]{1}[a-z0-9-_]{2,16}";

        private static bool checkLinkForId(string linkToUser)
        {
            return Regex.IsMatch(linkToUser, idPattern, RegexOptions.IgnoreCase);
        }
        private static bool checkLinkForNick(string linkToUser)
        {
            return Regex.IsMatch(linkToUser, nickPattern, RegexOptions.IgnoreCase);
        }
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
