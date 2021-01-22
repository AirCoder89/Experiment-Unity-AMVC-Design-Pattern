using System;
using AMVC.Core;
using AMVC.Systems.Main;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Application = AMVC.Core.Application;

namespace AMVC.Views.Main.History
{
    public class HistoryPanel : AppPanel
    {
        [Header("Internal References")]
        [SerializeField] private RectTransform scrollView;
        [SerializeField] private Button backBtn;
        [SerializeField] private Button nextBtn;
        [SerializeField] private Button previousBtn;

        [Header("Settings")] 
        [SerializeField] private float transitionSpeed;
        [SerializeField] private Ease transitionEase;
        
        private int _totalItems;
        private int _index;
        private bool _canTransition;
        private HorizontalLayoutGroup _horizontalLayout;
        private HistorySystem _system;
        
        public override void Initialize(AppView view, Application app)
        {
            base.Initialize(view, app);
            _horizontalLayout = scrollView.GetComponent<HorizontalLayoutGroup>();
            
            backBtn.onClick.AddListener(OnClickBack);
            nextBtn.onClick.AddListener(NextHistory);
            previousBtn.onClick.AddListener(PreviousHistory);
        }

        public override void OpenPanel(Action callBack = null)
        {
            _canTransition = true;
            _index = 0;
            ScrollTo(_index);
            base.OpenPanel(callBack);
        }

        public void Generate()
        {
            _system = GetSystem<HistorySystem>();
            _system.Generate(); //Generate histories items
        }

        private void OnClickBack()
        {
            
        }

        public void AddItem(HistoryItem item)
        {
            item.transform.SetParent(this.scrollView);
        }

        public void GenerateItemsComplete(int total)
        {
            _totalItems = total;
        }

        private void PreviousHistory()
        {
            if(_index <= 0 || !_canTransition) return;
            _index--;
            ScrollTo(_index);
        }

        private void NextHistory()
        {
            if(_index >= _totalItems || !_canTransition) return;
            _index++;
            ScrollTo(_index);
        }
        
        private void ScrollTo(int index)
        {
            _canTransition = false;
            if (_system == null) _system = GetSystem<HistorySystem>();
            this.scrollView.DOAnchorPos(-new Vector2(_system.GetItemPosition(index).x,0), this.transitionSpeed)
                .SetEase(this.transitionEase).OnComplete(() => { _canTransition = true; });
        }
    }
}
