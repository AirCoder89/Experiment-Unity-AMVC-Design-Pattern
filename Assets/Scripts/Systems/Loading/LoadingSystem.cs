using System;
using System.Linq;
using AMVC.Core;
using AMVC.Helper;
using AMVC.Models;
using AMVC.Views.Loading;
using Proyecto26;
using UnityEngine;
using Application = AMVC.Core.Application;

namespace AMVC.Systems.Loading
{
    public class LoadingSystem : AppSystem
    {
        public event Action<AppModel> OnComplete; 
        [Header("DataBase Parameters")]
        [SerializeField] private int timeOut;
        [SerializeField] private int retries;
        [SerializeField] private int retriesDelay;
        [SerializeField] private bool enableDebug;

        private AppModel _models;
        
        public override void Initialize(AppController controller, Application app)
        {
            base.Initialize(controller, app);
            _models = new AppModel();
            if(!DataBaseManager.IsInitialized)
                DataBaseManager.Initialize(timeOut, retries, retriesDelay, enableDebug);
        }

        private void OnError(string message)
        {
            Debug.LogError($"Loading error : {message}");
        }
        
        public void StartLoading()
        {
            GetPanel<LoadingPanel>().OpenPanel();
            var request = DataBaseManager.CreateRequest(ApiList.Missions);
            DataBaseManager.SendRequest(request, OnGetMissionsComplete, OnError);
        }

        private void OnGetMissionsComplete(string jsonResult)
        {
            _models.missions = JsonHelper.ArrayFromJson<MissionModel>(jsonResult).ToList();
            var request = DataBaseManager.CreateRequest(ApiList.History);
            DataBaseManager.SendRequest(request, OnGetHistoryComplete, OnError);
        }

        private void OnGetHistoryComplete(string jsonResult)
        {
            _models.history = JsonHelper.ArrayFromJson<HistoryModel>(jsonResult).ToList();
            LoadingComplete();
        }

        private void LoadingComplete()
        {
            OnComplete?.Invoke(this._models);
            application.LoadScene(SceneName.Main);
        }
    }
}