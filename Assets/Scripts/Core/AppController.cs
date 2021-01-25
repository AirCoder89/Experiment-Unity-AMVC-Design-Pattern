using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace AMVC.Core
{
    public class AppController : BaseMonoBehaviour
    {
       [ReorderableList]
        [SerializeField] public List<AppSystem> systems;
        private Dictionary<Type, AppSystem> _systems;
        
        public Application application { get; private set; }

        protected override void ReleaseReferences()
        {
            systems = null;
            _systems = null;
            application = null;
        }
        
        public void Initialize(Application app)
        {
            application = app;
            _systems = new Dictionary<Type, AppSystem>();
            foreach (var s in systems)
            {
                _systems.Add(s.GetType(), s);
                s.Initialize(this, app);
            }
        }

        public T GetSystem<T>() where T : AppSystem
        {
            if (!_systems.ContainsKey(typeof(T))) return null;
            return (T) _systems[typeof(T)];
        }
    
        public void Tick()
        {
            foreach (var system in systems)
                system.Tick();
        }

        [Button("Start")]
        public void StartController()
        {
            foreach (var system in systems)
            {
                system.StartSystem();
            }
        }
    
        [Button("Pause")]
        public void Pause()
        {
            foreach (var system in systems)
                system.PauseSystem();
        }
        [Button("Resume")]
        public void Resume()
        {
            foreach (var system in systems)
                system.ResumeSystem();
        }
        [Button("Reset")]
        public void ResetController()
        {
            foreach (var system in systems)
                system.ResetSystem();
        }

        
    }
}
