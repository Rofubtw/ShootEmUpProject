using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] Transform[] backgrounds; // Array of background layers
        [SerializeField] float smoothing = 10f; // How smooth the parallax effect is
        [SerializeField] float multiplier = 15f; // How much the parallax effect increments per layer
        
        private Transform cam; // Reference to the main camera transform
        private Vector3 previousCamPos; // Position of the camera in the previous frame

        void Awake() => cam = Camera.main.transform;

        void OnEnable() => previousCamPos = cam.position;

        void Update()
        {
            // Iterate through each background layer
            for (var i = 0; i < backgrounds.Length; i++)
            {
                var parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                var targetY = backgrounds[i].position.y + parallax;

                var targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);
                
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }
            
            previousCamPos = cam.position;
        }
    }
}