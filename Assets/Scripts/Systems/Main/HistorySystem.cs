using System;
using System.Collections.Generic;
using AMVC.Core;
using AMVC.Views.Main.History;
using UnityEngine;

namespace AMVC.Systems.Main
{
    public class HistorySystem : AppSystem
    {
        [SerializeField] private string historyItemName;
        private List<HistoryItem> _items;
        private bool _isGenerated;

        protected override void ReleaseReferences()
        {
            base.ReleaseReferences();
            _items = null;
        }
        
        public void Generate()
        {
            if(!_isGenerated) Clear();
            
            var pool = GetSystem<PoolSystem>();
            var panel = GetPanel<HistoryPanel>();
            
            foreach (var historyModel in application.models.history)
            {
                var item = pool.Spawn<HistoryItem>(this.historyItemName);
                item.Initialize(this.application);
                item.BindData(historyModel);
                _items.Add(item);
                panel.AddItem(item);
            }
            panel.GenerateItemsComplete(_items.Count);
            _isGenerated = true;
        }

        public void Clear()
        {
            if (_items == null)
            {
                _items = new List<HistoryItem>();
                return;
            }

            foreach (var item in _items)
                item.Remove();
            _items.Clear();
        }

        public Vector2 GetItemPosition(int index)
        {
            if(index >= this._items.Count)
                throw new Exception($"index {index} is out of range {_items.Count}");
            return _items[index].Position();
        }
    }
}
