using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu(menuName = "Events/GameObjectEventChannel")]
    public class GameObjectEventChannel : EventChannel<GameObject> { }
}