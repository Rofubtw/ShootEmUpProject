using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class PlayerHud : MonoBehaviour
    {
        [SerializeField] Image healthBar;
        [SerializeField] Image fuelBar;
        [SerializeField] TextMeshProUGUI scoreText;

        void Update()
        {
            healthBar.fillAmount = GameManager.Instance.Player.HealthNormalized;
            fuelBar.fillAmount = GameManager.Instance.Player.FuelNormalized;
            scoreText.text = $"Score: {GameManager.Instance.GetScore()}";
        }
    }
}