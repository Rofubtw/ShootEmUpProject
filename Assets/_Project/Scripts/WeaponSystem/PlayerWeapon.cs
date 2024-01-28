using System;
using UnityEngine;

namespace ShootEmUp
{
    public class PlayerWeapon : Weapon
    {
        float fireTimer;
        InputReader input;

        void Awake() => input = GetComponent<InputReader>();

        void Update()
        {
            fireTimer += Time.deltaTime;
            if (input.Fire && fireTimer >= weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}