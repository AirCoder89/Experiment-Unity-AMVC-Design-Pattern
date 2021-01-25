using System.Collections.Generic;
using AMVC.Core;
using AMVC.Views.Main;
using AMVC.Views.Main.Missions;
using UnityEngine;
using Application = AMVC.Core.Application;

namespace AMVC.Systems.Main
{
    public class MissionsSystem : AppSystem
    {
        [SerializeField] private string missionItemName;
        private List<MissionItem> _items;
        private bool _isGenerated;
        private MissionItem _selectedMission;

        private MissionPanel _p;

        private MissionPanel _panel
        {
            get
            {
                if (_p == null) _p = GetPanel<MissionPanel>();
                return _p;
            }
        }

        protected override void ReleaseReferences()
        {
            base.ReleaseReferences();
            _items = null;
            _selectedMission = null;
            _p = null;
            
            MissionItem.OnSelect -= OnSelectMissionItem;
        }

        public override void Initialize(AppController controller, Application app)
        {
            base.Initialize(controller, app);
            MissionItem.OnSelect += OnSelectMissionItem;
        }

        private void OnSelectMissionItem(MissionItem missionItem)
        {
            if(_selectedMission != null) _selectedMission.Unselect();
            _selectedMission = missionItem;
            _selectedMission.Select();
            _panel.Show(_selectedMission.model);
        }

        public void Generate()
        {
            if(!_isGenerated) Clear();
            var pool = GetSystem<PoolSystem>();
            
            foreach (var missionModel in application.models.missions)
            {
                var item = pool.Spawn<MissionItem>(this.missionItemName);
                item.Initialize(this.application);
                item.BindData(missionModel);
                _items.Add(item);
                _panel.AddItem(item);
            }
            
            _isGenerated = true;
            
        }
        
        public void Clear()
        {
            if (_items == null)
            {
                _items = new List<MissionItem>();
                return;
            }

            foreach (var item in _items)
                item.Remove();
            _items.Clear();
        }
    }
}
