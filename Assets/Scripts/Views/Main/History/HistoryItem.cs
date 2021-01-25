using AMVC.Core;
using AMVC.Models;
using AMVC.Systems;
using UnityEngine;
using UnityEngine.UI;
using Application = AMVC.Core.Application;

namespace AMVC.Views.Main.History
{
    public class HistoryItem : BaseMonoBehaviour , IPoolItem
    {
        [SerializeField] private Text titleTxt;
        [SerializeField] private Text detailsTxt;
        
        private Application _application;
        private bool _isInitialized;
        private RectTransform _rt;

        private RectTransform _rectTransform
        {
            get
            {
                if (_rt == null) _rt = GetComponent<RectTransform>();
                return _rt;
            }
        }

        protected override void ReleaseReferences()
        {
            titleTxt = null;
            detailsTxt = null;
            _application = null;
            _rt = null;
        }

        public void Initialize(Application app)
        {
            if(_isInitialized) return;
            _isInitialized = true;
            _application = app;
        }

        public void BindData(HistoryModel model)
        {
            this.titleTxt.text = model.title;
            this.detailsTxt.text = model.details;
        }

        public void Remove()
        {
            _application.GetSystem<PoolSystem>().Despawn(this.transform);
        }

        public Vector2 Position() => _rectTransform.anchoredPosition;
    }
}
