using AMVC.Core;
using UnityEngine;
using UnityEngine.UI;

namespace AMVC.Views.Loading
{
    public class LoadingPanel : AppPanel
    {
        [SerializeField] private Image loadingProgress;
        //add progress bar or show a loading animation here

        public void UpdateProgress(float progress)
        {
            this.loadingProgress.fillAmount = progress;
        }
    }
}