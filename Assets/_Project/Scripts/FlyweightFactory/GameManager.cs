using Eflatun.SceneReference;
using RofoLib;
using UnityEngine;

namespace ShootEmUp
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] GameObject gameOverUI;
        
        public Player Player => player;
        public bool IsGameOver => player.HealthNormalized <= 0 || player.FuelNormalized <= 0;
        
        Player player;
        int score;
        float restartTimer = 3f;

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.FindGameObjectWithTag("Player").GetOrAdd<Player>();
        }
        
        void Update()
        {
            if (IsGameOver)
            {
                restartTimer -= Time.deltaTime;

                if (gameOverUI.activeSelf == false)
                {
                    gameOverUI.SetActive(true);
                }
                
                if (restartTimer <= 0)
                {
                    Loader.Load(mainMenuScene);
                }
            }
        }
        
        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}
