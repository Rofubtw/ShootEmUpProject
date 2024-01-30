using Eflatun.SceneReference;
using RofoLib;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] SceneReference firstLevel;
        [SerializeField] Button playButton;
        [SerializeField] Button quitButton;

        void Awake()
        {
            playButton.onClick.AddListener(() => Loader.Load(firstLevel));
            quitButton.onClick.AddListener(() => Helpers.QuitGame());
            Time.timeScale = 1f;
        }
    }
}