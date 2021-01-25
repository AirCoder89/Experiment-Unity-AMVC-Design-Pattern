using AMVC.Core;
using AMVC.Views.Main.History;
using AMVC.Views.Main.Missions;
using UnityEngine;
using UnityEngine.UI;
using Application = AMVC.Core.Application;

namespace AMVC.Views.Main
{
    public class MenuPanel : AppPanel
    {
        [SerializeField] private Button missionBtn;
        [SerializeField] private Button historyBtn;

        protected override void ReleaseReferences()
        {
            base.ReleaseReferences();
            missionBtn = null;
            historyBtn = null;
        }

        public override void Initialize(AppView view, Application app)
        {
            base.Initialize(view, app);
            this.missionBtn.onClick.AddListener(OpenMissionPanel);
            this.historyBtn.onClick.AddListener(OpenHistoryPanel);
        }

        private void OpenHistoryPanel()
        {
            ClosePanel(() =>
            {
                GetPanel<HistoryPanel>().OpenPanel();
            });
        }

        private void OpenMissionPanel()
        {
            ClosePanel(() =>
            {
                GetPanel<MissionPanel>().OpenPanel();
            });
        }
    }
}
