using UnityEngine;

namespace AMVC.Core
{
    public class AppScene : BaseMonoBehaviour
    {
        public AppView views;
        public AppController controller;
    
        private static AppScene _instance;
        private void Awake()
        {
            if(_instance != null) return;
            _instance = this;
        }

        public static AppView appView => AppScene._instance.views;
        public static AppController appController => AppScene._instance.controller;
    }
}
