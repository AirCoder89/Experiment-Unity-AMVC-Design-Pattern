using System.Collections.Generic;
using AMVC.Models;
using UnityEngine;

namespace AMVC.Core
{
    [System.Serializable]
    public class AppModel
    {
        public List<MissionModel> missions;
        public List<HistoryModel> history;
    }
}
