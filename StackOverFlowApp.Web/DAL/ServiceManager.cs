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
        private string _serviceUrl = "https://api.stackexchange.com/2.2/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow&filter=withbody";

        private IServiceOperation _serviceOperation;
        public ServiceManager(IServiceOperation serviceOperation)
        {
            _serviceOperation = serviceOperation;
        }

        //public ServiceManager(string questionId)
        //{
        //    if (!string.IsNullOrEmpty(questionId))
        //    {                
        //        _serviceUrl = string.Format("https://api.stackexchange.com/2.1/questions/{0}?order=desc&sort=activity&site=stackoverflow&filter=withbody", questionId);
        //    }
        //}

        public Item GetQuestionById(string questionId)
        {
            try
            {
                if (!string.IsNullOrEmpty(questionId))
                {
                    _serviceUrl = string.Format("https://api.stackexchange.com/2.1/questions/{0}?order=desc&sort=activity&site=stackoverflow&filter=withbody", questionId);
                }
                else
                {
                    return null;
                }

                //Web Request Call
                var responseJson = _serviceOperation.CallService(_serviceUrl);

                if (!string.IsNullOrEmpty(responseJson))
                {
                    var myDeserializedObjList = (RootObject)JsonConvert.DeserializeObject(responseJson, typeof(RootObject));
                    return myDeserializedObjList.items[0];
                }
            }
            catch (Exception ex)
            {
                Utilities.LogError(ex.Message, ex.StackTrace, "ServiceManager>>GetQuestionById Function Error");
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
                var responseJson = _serviceOperation.CallService((_serviceUrl));

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
    }
}