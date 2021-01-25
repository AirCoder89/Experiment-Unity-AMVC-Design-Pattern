using System;
using System.Collections.Generic;
using AMVC.Models;
using AMVC.Views.Loading;
using AMVC.Views.Main.History;
using NaughtyAttributes;
using UnityEngine;

namespace AMVC.Core
{
    public class AppView : BaseMonoBehaviour
    {
        [HorizontalLine(2f, EColor.Blue)]
        public AppPanel defaultPanel;
    
        
        [ReorderableList] [SerializeField] private List<AppPanel> panels;
        private Dictionary<Type, AppPanel> _panels;
        public Application application { get; private set; }
    
        public T GetPanel<T>() where T : AppPanel
        {
            if (!_panels.ContainsKey(typeof(T)))
            {
                Debug.LogWarning($"Panel {typeof(T)} not found");
                return null;
            }
            return (T) _panels[typeof(T)];
        }

        protected override void ReleaseReferences()
        {
            defaultPanel = null;
            panels = null;
            _panels = null;
            application = null;
        }
        
        public void Initialize(Application app)
        {
            application = app;
            _panels = new Dictionary<Type, AppPanel>();
            foreach (var panel in panels)
            {
                panel.Initialize(this, app);
                _panels.Add(panel.GetType(), panel); 
                panel.ClosePanelImmediately();
            }
            
            if(defaultPanel) defaultPanel.OpenPanel();
        }

        public void Tick()
        {
            foreach (var panel in _panels)
                panel.Value.Tick();
        }

        [Button("Pause")]
        public void Pause()
        {
            foreach (var panel in _panels)
                panel.Value.PausePanel();
        }
        [Button("Resume")]
        public void Resume()
        {
            foreach (var panel in _panels)
                panel.Value.ResumePanel();
        }
        [Button("Reset")]
        public void ResetView()
        {
            foreach (var panel in _panels)
                panel.Value.ResetPanel();
        }
        [Button("Close All Panels")]
        public void CloseAllPanel()
        {
            foreach (var panel in _panels)
                panel.Value.ClosePanelImmediately();
        }
    }
}
