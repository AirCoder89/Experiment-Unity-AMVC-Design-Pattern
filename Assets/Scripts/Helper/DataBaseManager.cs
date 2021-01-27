using System;
using Proyecto26;
using UnityEngine;

namespace AMVC.Helper
{
    public static class DataBaseManager
    {
        // private variables holds settings
        private static int _timeOut;
        private static int _retries;
        private static int _retriesDelay;
        private static bool _enableDebug;

        public static bool IsInitialized;
        
        //Initialize the Data Manager
        public static void Initialize(int timeOut, int retries, int retriesDelay, bool debug)
        {
            _timeOut = timeOut;
            _retries = retries;
            _retriesDelay = retriesDelay;
            _enableDebug = debug;
            IsInitialized = true;
        }

        public static RequestHelper CreateRequest(string uri)
        {
            return new RequestHelper()
            {
                Uri = uri,
                Timeout = _timeOut,
                Retries = _retries,
                EnableDebug = _enableDebug,
                RetrySecondsDelay = _retriesDelay,
                Method = "GET",
                ContentType = "application/json"
            };
        }
        
        //Execute the request and fire (invoke) the corresponding callback 
        public static void SendRequest(RequestHelper request, Action<string> onComplete, Action<string> onError)
        {
            RestClient.Request(request)
         
                .Then(response =>
                {
                    onComplete?.Invoke(response.Text);
                    RestClient.ClearDefaultHeaders();
                })
                .Catch(err =>
                {
                    onError?.Invoke(err.Message);
                }) ;
        }
        
        //overloading SendRequest method
        public static void SendRequest(string uri, Action<string> onComplete, Action<string> onError)
        {
            RestClient.Request(CreateRequest(uri))
         
                .Then(response =>
                {
                    onComplete?.Invoke(response.Text);
                    RestClient.ClearDefaultHeaders();
                })
                .Catch(err =>
                {
                    onError?.Invoke(err.Message);
                });
        }
        
    }

}
