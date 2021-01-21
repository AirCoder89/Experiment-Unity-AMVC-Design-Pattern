using UnityEngine;

namespace AMVC.Core
{
    public abstract class AppSystem : BaseMonoBehaviour
    {
        public AppController Controller { get; protected set; }
        public Application application { get; protected set; }

        protected bool IsRun;
        protected bool IsInitialized;
    
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

        public virtual void ResetSystem()
        {
        
        }

        public virtual void StartSystem()
        {
            IsRun = true;
        }
    
        public virtual void PauseSystem()
        {
            IsRun = false;
        }

        public virtual void ResumeSystem()
        {
            IsRun = true;
        }
    }
}