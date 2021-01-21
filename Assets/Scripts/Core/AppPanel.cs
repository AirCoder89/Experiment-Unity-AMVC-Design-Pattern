using UnityEngine;

namespace AMVC.Core
{
    [RequireComponent(typeof(Canvas))]
    public abstract class AppPanel : BaseMonoBehaviour
    {
        public AppView View { get; protected set; }
        public Application application { get; protected set; }

        private Canvas _c;

        protected Canvas canvas
        {
            get
            {
                if (_c == null) _c = GetComponent<Canvas>();
                return _c;
            }
        }
        
        public virtual void Initialize(AppView view, Application app)
        {
            View = view;
            application = app;
        }

        public T GetSystem<T>() where T : AppSystem
        {
            return application.controllers.GetSystem<T>();
        }
        public T GetPanel<T>() where T : AppPanel
        {
            return application.GetPanel<T>();
        }
        public virtual void Tick(){}

        public virtual void ResetPanel(){}

        public virtual void PausePanel(){}

        public virtual void ResumePanel(){}

        public virtual void OpenPanel()
        {
            canvas.enabled = true;
        }

        public virtual void ClosePanel()
        {
            canvas.enabled = false;
        }
    }
}