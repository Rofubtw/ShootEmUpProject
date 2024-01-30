using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class PlayerHud : MonoBehaviour
    {
        [SerializeField] Image healthBar;
        [SerializeField] Image fuelBar;

        void Update()
        {
            healthBar.fillAmount = GameManager.Instance.Player.HealthNormalized;
            fuelBar.fillAmount = GameManager.Instance.Player.FuelNormalized;
        }
    }
}