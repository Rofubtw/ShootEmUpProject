using UnityEngine;

namespace ShootEmUp
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected float amount = 50f;
    }
}