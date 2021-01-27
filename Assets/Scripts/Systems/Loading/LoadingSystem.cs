using System;
using System.Linq;
using AMVC.Core;
using AMVC.Helper;
using AMVC.Models;
using AMVC.Systems.Loading.CommandDp;
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
        private CommandInvoker _invoker;
        
        protected override void ReleaseReferences()
        {
            base.ReleaseReferences();
            _models = null;
        }
        
        public override void Initialize(AppController controller, Application app)
        {
            base.Initialize(controller, app);
            _models = new AppModel();
            if(!DataBaseManager.IsInitialized)
                DataBaseManager.Initialize(timeOut, retries, retriesDelay, enableDebug);
        }

        public void StartLoading()
        {
            GetPanel<LoadingPanel>().OpenPanel();
            
            _invoker = GetSystem<CommandInvoker>();
            
            // create mission command
            var missionCommand = new LoadingCommand<MissionModel>(ApiList.Missions);
            missionCommand.OnComplete += result => _models.missions = result;
            _invoker.AddCommand(missionCommand);

            //create history command
            var historyCommand = new LoadingCommand<HistoryModel>(ApiList.History);
            historyCommand.OnComplete += result => _models.history = result;
            _invoker.AddCommand(historyCommand);
            
            _invoker.OnComplete += LoadingComplete;
            _invoker.StartInvoker();
        }

        private void LoadingComplete()
        {
            OnComplete?.Invoke(this._models);
            application.LoadScene(SceneName.Main);
        }
    }
}