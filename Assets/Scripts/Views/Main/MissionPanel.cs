using AMVC.Core;
using AMVC.Models;
using AMVC.Views.Main.Missions;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Application = AMVC.Core.Application;

namespace AMVC.Views.Main
{
    public class MissionPanel : AppPanel
    {
        [SerializeField] private Button backBtn;
        [SerializeField] private MissionPopup[] popups = new MissionPopup[2]; 
        [SerializeField] private RectTransform itemsHolder;
        
        [Header("Settings")] 
        public float tweenSpeed;
        public Ease showEase;
        public Ease hideEase;

        private bool _popup0OnScreen;
        
        public override void Initialize(AppView view, Application app)
        {
            base.Initialize(view, app);
            _popup0OnScreen = false;
            backBtn.onClick.AddListener(BackToMainApp);
            foreach (var popup in popups)
                popup.Initialize(this);
        }

        private void BackToMainApp()
        {
            ClosePanel(() =>
            {
                GetPanel<MenuPanel>().OpenPanel();
            });
        }

        public void AddItem(MissionItem item)
        {
            item.transform.SetParent(this.itemsHolder);
        }

        public void Show(MissionModel missionModel)
        {
            if (_popup0OnScreen)
            {
                if(popups[0].onScreen) popups[0].Hide();
                popups[1].Show(missionModel);
                _popup0OnScreen = false;
                return;
            }
            _popup0OnScreen = true;
            if(popups[1].onScreen) popups[1].Hide();
            popups[0].Show(missionModel);
        }

    }
}
