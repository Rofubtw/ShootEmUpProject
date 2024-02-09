using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public abstract class Flyweight : MonoBehaviour
    {
        public FlyweightSettings settings; // Intrinsic state
        public bool IsAlive { get; set; }

        protected virtual IEnumerator DespawnAfterDelay(float time, Flyweight poolableObj)
        {
            yield return RofoLib.Helpers.GetWaitForSeconds(time);
            
            poolableObj.transform.SetParent(null);
            FlyweightFactory.ReturnToPool(poolableObj);
        }
    }
}