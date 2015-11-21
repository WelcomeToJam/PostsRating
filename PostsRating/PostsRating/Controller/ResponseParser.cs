using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace PostsRating.Controller
{
    // Класс преобразющий json ответ в List<string>.
    class ResponseParser
    {
        // Возвращает список строк из json ответа.
        public static List<string> parseResponse(string response)
        {
            try
            {
                JObject json = JObject.Parse(response);
                List<string> idArr = new List<string>();
                if (json["response"] != null)
                {
                    foreach (var id in json["response"])
                    {
                        idArr.Add(Convert.ToString(id));
                    }
                }
                return idArr;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
        }
        // Возвращает список строк из json ответа с указанием перода времени, 
        // за который следует брать строки.
        public static List<string> parseResponse(string response, int timeToLive)
        {
            try
            {
                JObject json = JObject.Parse(response);
                List<string> idArr = new List<string>();
                if (json["response"] != null)
                {
                    foreach (JToken id in json["response"])
                    {
                        if (id.Next != null)
                        {
                            int postTime = Convert.ToInt32(id.Next["date"]);
                            if (postTime > timeToLive)
                            {
                                idArr.Add(Convert.ToString(id.Next["id"]));
                            }
                            else
                            {
                                break;
                            }
                        } // if (id.Next)
                    } // foreach
                } // if (json["response"]
                return idArr;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        } // end of method
        public static int getNumberElements(string response)
        {
            try
            {
                JObject json = JObject.Parse(response);   
                var count = json["response"];

                if (count != null)
                {
                    return Convert.ToInt32(count["count"]);
                }
                else
                {
                    return 0;
                }                
                
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }
    }
}
