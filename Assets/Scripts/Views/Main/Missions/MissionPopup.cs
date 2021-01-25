using AMVC.Core;
using AMVC.Models;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace AMVC.Views.Main.Missions
{
    public class MissionPopup : BaseMonoBehaviour
    {
        [SerializeField] private Text titleTxt;
        [SerializeField] private Text descriptionTxt;

        [Header("Movement Settings")] 
        [SerializeField] private Vector2 startPos;
        [SerializeField] private float inScreenYPos;
        [SerializeField] private float outScreenYPos;

        public bool onScreen;
        private CanvasGroup _cGroup;
        private RectTransform _rt;
        private MissionPanel _parentPanel;
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
            _parentPanel = null;
            _rt = null;
            titleTxt = null;
            _cGroup = null;
            descriptionTxt = null;
        }

        public void Initialize(MissionPanel parentPanel)
        {
            _cGroup = GetComponent<CanvasGroup>();
            _parentPanel = parentPanel;
            _rectTransform.anchoredPosition = startPos;
            onScreen = false;
        }
        
        public void Show(MissionModel model)
        {
            onScreen = true;
            titleTxt.text = model.mission_name;
            descriptionTxt.text = model.description;
            //init animation
            _cGroup.alpha = 0;
            _rectTransform.localScale = new Vector3(1.25f, 1.25f);
            _rectTransform.anchoredPosition = startPos;
            //do animation
            _cGroup.DOFade(1, _parentPanel.tweenSpeed);
            _rectTransform.DOScale(Vector3.one, _parentPanel.tweenSpeed).SetEase(_parentPanel.showEase);;
            _rectTransform.DOAnchorPosY(inScreenYPos, _parentPanel.tweenSpeed).SetEase(_parentPanel.showEase);
        }

        public void Hide()
        {
            onScreen = false;
            //init animation
            _rectTransform.anchoredPosition = new Vector2(0, inScreenYPos);
            //do animation
            _cGroup.DOFade(0, _parentPanel.tweenSpeed);
            _rectTransform.DOAnchorPosY(outScreenYPos, _parentPanel.tweenSpeed).SetEase(_parentPanel.hideEase).OnComplete(
                () =>
                {
                    _rectTransform.anchoredPosition = startPos;
                });
        }
    }
}
