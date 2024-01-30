using System.Collections.Generic;
using Eflatun.SceneReference;
using UnityEngine.SceneManagement;
using MEC;

namespace ShootEmUp
{
    public static class Loader
    {
        static SceneReference loadingScene =
            new(SceneGuidToPathMapProvider.ScenePathToGuidMap["Assets/_Project/Scenes/Loading.unity"]);
        static SceneReference targetScene;
        
        public static void Load(SceneReference scene)
        {
            targetScene = scene;
            SceneManager.LoadScene("Loading");
            Timing.RunCoroutine(LoadTargetScene());
        }

        static IEnumerator<float> LoadTargetScene()
        {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(targetScene.Name);
        }
    }
}