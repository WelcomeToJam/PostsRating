﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace PostsRating.Controller
{
    class ResponseParser
    {
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
                            //if (Convert.ToInt32(id.Next["date"]) > timeToLive)
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
    }
}
