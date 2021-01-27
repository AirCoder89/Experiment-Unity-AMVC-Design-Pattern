using System;
using System.Windows.Input;
using AMVC.Core;
using AMVC.Models;
using AMVC.Systems;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Application = AMVC.Core.Application;

namespace AMVC.Views.Main.Missions
{
    public class MissionItem : BaseMonoBehaviour, IPoolItem
    {
        [SerializeField] private Text missionIdTxt;
        public static event Action<MissionItem> OnSelect;
        
        public MissionModel model { get; private set; }
        private Button _button;
        private Application _application;
        private bool _isInitialized;

        protected override void ReleaseReferences()
        {
            _application = null;
            _button = null;
            model = null;
            missionIdTxt = null;
        }

        public void Initialize(Application app)
        {
            if(_isInitialized) return;
            _isInitialized = true;
            _application = app;
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() =>
            {
                OnSelect?.Invoke(this);
            });
        }

        public void BindData(MissionModel mModel)
        {
            this.model = mModel;
            missionIdTxt.text = this.model.mission_id;
        }

        public void Select()
        {
            _button.interactable = false;
        }

        public void Unselect()
        {
            _button.interactable = true;
        }

        public void Remove()
        {
            _application.GetSystem<PoolSystem>().Despawn(this.transform);
        }

    }
}
