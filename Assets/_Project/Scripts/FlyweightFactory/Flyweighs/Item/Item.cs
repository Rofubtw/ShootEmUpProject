using UnityEngine;

namespace ShootEmUp
{
    public abstract class Item : Flyweight
    {
        float speed = 0.2f;
        float smoothing = 10f;
        
        void Update()
        {
            var targetY = transform.position.y - speed;
            var targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}