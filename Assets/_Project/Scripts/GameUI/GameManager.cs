using RofoLib;
using UnityEngine;

namespace ShootEmUp
{
    public class GameManager : Singleton<GameManager>
    {
        public Player Player => player;
        public bool IsGameOver => player.HealthNormalized <= 0 || player.FuelNormalized <= 0;
        
        Player player;
        int score;

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.FindGameObjectWithTag("Player").GetOrAdd<Player>();
        }

        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}
