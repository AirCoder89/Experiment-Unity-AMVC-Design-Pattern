using System;
using System.Collections.Generic;
using AMVC.Models;
using AMVC.Views.Loading;
using AMVC.Views.Main.History;
using UnityEngine;

namespace AMVC.Core
{
    public class AppView : BaseMonoBehaviour
    {
        public AppPanel defaultPanel;
    
        [SerializeField] private List<AppPanel> panels;
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

        public void Pause()
        {
            foreach (var panel in _panels)
                panel.Value.PausePanel();
        }
    
        public void Resume()
        {
            foreach (var panel in _panels)
                panel.Value.ResumePanel();
        }
    
        public void Reset()
        {
            foreach (var panel in _panels)
                panel.Value.ResetPanel();
        }

        public void CloseAllPanel()
        {
            foreach (var panel in _panels)
                panel.Value.ClosePanelImmediately();
        }
    }
}
