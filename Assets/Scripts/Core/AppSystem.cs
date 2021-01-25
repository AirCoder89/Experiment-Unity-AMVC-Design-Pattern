using NaughtyAttributes;
using UnityEngine;

namespace AMVC.Core
{
    public abstract class AppSystem : BaseMonoBehaviour
    {
        public AppController Controller { get; protected set; }
        public Application application { get; protected set; }

        protected bool IsRun;
        protected bool IsInitialized;

        protected override void ReleaseReferences()
        {
            Controller = null;
            application = null;
        }
    
        public virtual void Initialize(AppController controller, Application app)
        {
            this.Controller = controller;
            this.application = app;
            IsInitialized = true;
        }

        public T GetPanel<T>() where T : AppPanel
        {
            return application.GetPanel<T>();
        }
    
        public T GetSystem<T>() where T : AppSystem
        {
            return application.GetSystem<T>();
        }

        public virtual void Tick()
        {
            if(!IsRun) return;
        }

        [Button("Start System")]
        public virtual void StartSystem()
        {
            IsRun = true;
        }
    
        [Button("Pause System")]
        public virtual void PauseSystem()
        {
            IsRun = false;
        }

        [Button("Resume System")]
        public virtual void ResumeSystem()
        {
            IsRun = true;
        }
        
        [Button("Reset System")]
        public virtual void ResetSystem()
        {
        
        }
    }
}