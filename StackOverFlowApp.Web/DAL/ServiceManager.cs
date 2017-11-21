using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using StackOverFlowApp.Web.Interface;
using StackOverFlowApp.Web.Models;

namespace StackOverFlowApp.Web.DAL
{
    public class ServiceManager : IServiceManager
    {
        private readonly string _serviceUrl = string.Empty;

        public ServiceManager()
        {
            _serviceUrl = "https://api.stackexchange.com/2.2/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow&filter=withbody";
        }

        public ServiceManager(string questionId)
        {
            if (!string.IsNullOrEmpty(questionId))
            {
                //_serviceUrl = string.Format("https://api.stackexchange.com/2.2/questions/{0}?pagesize=1&order=desc&sort=activity&site=stackoverflow&filter=withbody",questionId);
                _serviceUrl = string.Format("https://api.stackexchange.com/2.1/questions/{0}?order=desc&sort=activity&site=stackoverflow&filter=withbody", questionId);
            }
        }

        public Item GetQuestionById(string questionId)
        {
            try
            {
                if (string.IsNullOrEmpty(_serviceUrl))
                {
                    return null;
                }

                //Web Request Call
                var responseJson = RequestCall(_serviceUrl);

                if (!string.IsNullOrEmpty(responseJson))
                {
                    var myDeserializedObjList = (RootObject)JsonConvert.DeserializeObject(responseJson, typeof(RootObject));
                    return myDeserializedObjList.items[0];
                }
            }
            catch (Exception ex)
            {
                Utilities.LogError(ex.Message, ex.StackTrace, "ServiceBuilder>>GetQuestionById Function Error");
            }
            return null;
        }
        public IEnumerable<Item> GetTopQuestions()
        {
            try
            {
                if (string.IsNullOrEmpty(_serviceUrl))
                {
                    return null;
                }

                //Web Request Call
                var responseJson = RequestCall(_serviceUrl);

                if (!string.IsNullOrEmpty(responseJson))
                {
                    var myDeserializedObjList = (RootObject)JsonConvert.DeserializeObject(responseJson, typeof(RootObject));
                    return myDeserializedObjList.items;
                }
            }
            catch (Exception ex)
            {
                Utilities.LogError(ex.Message, ex.StackTrace, "ServiceBuilder>>GetTopQuestions Function Error");
            }
            return null;
        }

        private string RequestCall(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
           // request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();

            string content;

            using (Stream stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            return content;
        }
    }
}