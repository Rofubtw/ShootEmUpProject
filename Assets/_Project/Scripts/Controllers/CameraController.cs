﻿using UnityEngine;

namespace ShootEmUp
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] float speed = 2f;
        
        void Start() => transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        void LateUpdate()
        {
            // Move the camera along the battlefield
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
    }
}