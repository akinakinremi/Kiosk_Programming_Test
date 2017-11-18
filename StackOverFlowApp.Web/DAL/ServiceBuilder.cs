using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using StackOverFlowApp.Web.Interface;
using StackOverFlowApp.Web.Models;

namespace StackOverFlowApp.Web.DAL
{
    public class ServiceBuilder : IServiceBuilder
    {
        private string _serviceUrl = string.Empty;

        public void SetMainUrl()
        {
            _serviceUrl = "https://api.stackexchange.com/2.2/questions?";
        }
        public void SetUrlPagesizeParameters()
        {
            if (!string.IsNullOrEmpty(_serviceUrl))
            {
                _serviceUrl += "pagesize=50";
            }
        }
        public void SetUrlOrderParameters()
        {
            if (!string.IsNullOrEmpty(_serviceUrl))
            {
                _serviceUrl += "&" + "order=desc";
            }
        }
        public void SetUrlSortParameters()
        {
            if (!string.IsNullOrEmpty(_serviceUrl))
            {
                _serviceUrl += "&" + "sort=creation";
            }
        }
        public void SetUrlSiteParameters()
        {
            if (!string.IsNullOrEmpty(_serviceUrl))
            {
                _serviceUrl += "&" + "site=stackoverflow";
            }
        }
        public string GetCompleteUrl()
        {
            if (!string.IsNullOrEmpty(_serviceUrl))
            { return _serviceUrl; }

            return string.Empty;
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