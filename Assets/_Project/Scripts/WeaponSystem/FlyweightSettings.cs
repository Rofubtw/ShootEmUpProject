using System;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/Flyweight Settings")]
    public class FlyweightSettings : ScriptableObject
    {
        public FlyweightType type;
        public GameObject prefab;
        public float despawnDelay = 5f;
        public float speed = 10f;

        public virtual Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.AddComponent<Flyweight>();
            flyweight.settings = this;

            return flyweight;
        }

        public virtual void OnGet(Flyweight f) => f.gameObject.SetActive(true);
        public virtual void OnRelease(Flyweight f) => f.gameObject.SetActive(false);
        public virtual void OnDestroyPoolObject(Flyweight f) => Destroy(f.gameObject);
    }

    public enum FlyweightType
    {
        Red,
        Yellow,
        Rocket
    }
}