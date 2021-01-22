using AMVC.Core;
using PathologicalGames;
using UnityEngine;

namespace AMVC.Systems
{
    public class PoolSystem : AppSystem
    {
        public T Spawn<T>(string itemName) where T : IPoolItem
        {
            return PoolManager.Pools[application.parameters.poolName].Spawn(itemName)
                .gameObject.GetComponent<T>();
        }

        public void Despawn(Transform item)
        {
            PoolManager.Pools[application.parameters.poolName].Despawn(item, PoolManager.Pools[application.parameters.poolName].transform);
        }
    }
}