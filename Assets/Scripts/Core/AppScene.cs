using NaughtyAttributes;
using UnityEngine;

namespace AMVC.Core
{
    public class AppScene : BaseMonoBehaviour
    {
        [HorizontalLine(2f, EColor.Blue)]
        [Required] public AppView views;
        [Required] public AppController controller;
    
        private static AppScene _instance;
        
        protected override void ReleaseReferences()
        {
            views = null;
            controller = null;
            _instance = null;
        }
        
        private void Awake()
        {
            if(_instance != null) return;
            _instance = this;
        }

        public static AppView appView => AppScene._instance.views;
        public static AppController appController => AppScene._instance.controller;
        
    }
}
