using System;
using System.Collections.Generic;
using System.Linq;
using AMVC.Helper;
using AMVC.Models;
using Proyecto26;
using UnityEngine;

namespace AMVC.Systems.Loading.CommandDp
{
    public class LoadingCommand<T> : ICommand
    {
        public event Action<List<T>> OnComplete;
        public bool IsDone { get;  private set;}
        
        private string _uri;
        
        public LoadingCommand(string uri)
        {
            this._uri = uri;
        }

        public void Execute()
        {
            Debug.Log("Execute !!");
            IsDone = false;
            var request = DataBaseManager.CreateRequest(_uri);
            DataBaseManager.SendRequest(request, Completed, OnError);
        }

        private void Completed(string jsonResult)
        {
            IsDone = true;
            OnComplete?.Invoke(JsonHelper.ArrayFromJson<T>(jsonResult).ToList());
        }

        public void Dispose()
        {
            OnComplete = null;
        }
        
        private void OnError(string errorMessage)
        {
            Debug.LogError($"Loading {_uri} Failed ! => {errorMessage}");
        }
    }
}