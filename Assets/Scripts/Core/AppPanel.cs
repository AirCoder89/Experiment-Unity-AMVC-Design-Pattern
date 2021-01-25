using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace AMVC.Core
{
    [RequireComponent(typeof(Canvas))]
    public abstract class AppPanel : BaseMonoBehaviour
    {
        public AppView View { get; protected set; }
        public Application application { get; protected set; }

        private Canvas _c;
        private CanvasGroup _cGroup;
        protected bool isOpen;
        protected Canvas canvas
        {
            get
            {
                if (_c == null) _c = GetComponent<Canvas>();
                return _c;
            }
        }

        protected override void ReleaseReferences()
        {
            View = null;
            application = null;
            _c = null;
            _cGroup = null;
        }
        public virtual void Initialize(AppView view, Application app)
        {
            View = view;
            application = app;
            isOpen = true;
        }
        
        protected CanvasGroup canvasGroup
        {
            get
            {
                if (_cGroup == null) _cGroup = GetComponent<CanvasGroup>();
                return _cGroup;
            }
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

        [Button("Pause Panel")]
        public virtual void PausePanel(){}

        [Button("Resume Panel")]
        public virtual void ResumePanel(){}
        [Button("Reset Panel")]
        public virtual void ResetPanel(){}

          //- Canvas visibility methods
        public virtual void OpenPanelImmediately()
        {
            if(isOpen) return;
            isOpen = true;
            canvas.enabled = true;
            canvasGroup.alpha = 1f;
        }
        
        public virtual void OpenPanel(Action callBack = null)
        {
            if(isOpen) return;
            isOpen = true;
            canvas.enabled = true;

            canvasGroup.alpha = 0f;
            canvasGroup.DOFade(1f, application.parameters.panelsFadeSpeed).OnComplete(() =>
            {
                callBack?.Invoke();
            });
        }
        
        public virtual void ClosePanelImmediately()
        {
            if(!isOpen) return;
            isOpen = false;
            canvasGroup.alpha = 0;
            canvas.enabled = false;
        }
        public virtual void ClosePanel(Action callBack = null)
        {
            if(!isOpen) return;
            isOpen = false;

            canvasGroup.alpha = 1f;
            canvasGroup.DOFade(0f, application.parameters.panelsFadeSpeed).OnComplete(() =>
            {
                callBack?.Invoke();
                canvas.enabled = false;
            });
        }
    }

}