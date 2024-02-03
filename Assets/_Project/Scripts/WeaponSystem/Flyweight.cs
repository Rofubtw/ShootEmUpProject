using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public abstract class Flyweight : MonoBehaviour
    {
        public FlyweightSettings settings; // Intrinsic state
        protected bool isAlive = true;
        protected virtual IEnumerator DespawnAfterDelay(float time, Flyweight poolableObj)
        {
            yield return RofoLib.Helpers.GetWaitForSeconds(time);

            if (isAlive)
            {
                poolableObj.transform.SetParent(null);
                FlyweightFactory.ReturnToPool(poolableObj);
            }
        }
    }
}