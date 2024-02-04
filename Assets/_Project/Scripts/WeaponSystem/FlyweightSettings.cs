using System;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/Flyweight Settings")]
    public abstract class FlyweightSettings : ScriptableObject
    {
        public FlyweightType type;
        public GameObject prefab;

        public abstract Flyweight Create();
        
        public virtual void OnGet(Flyweight f) => f.gameObject.SetActive(true);
        public virtual void OnRelease(Flyweight f) => f.gameObject.SetActive(false);
        public virtual void OnDestroyPoolObject(Flyweight f) => Destroy(f.gameObject);
    }

    public enum FlyweightType
    {
        RedBullet,
        BlueBullet,
        YellowBullet,
        RedFlash,
        BlueFlash,
        YellowFlash,
        RedHit,
        BlueHit,
        YellowHit,
        Rocket,
        RocketFlash,
        RocketHit,
        RocketDisable,
    }
}