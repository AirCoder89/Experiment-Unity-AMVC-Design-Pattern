using UnityEngine;

namespace AMVC.Core
{
    [CreateAssetMenu(menuName = "Application/Parameters")]
    public class AppParameters : ScriptableObject
    {
        public float panelsFadeSpeed = 0.35f;
        public string poolName;
    }
}