using System.Collections.Generic;
using UnityEngine;

namespace RofoLib
{
    public static class Helpers
    {
        static readonly Dictionary<float, WaitForSeconds> WaitForSeconds = new();

        /// <summary>
        /// Returns a WaitForSeconds object for the specified duration </summary>
        /// <param name="seconds">The duration in seconds to wait.</param>
        /// <returns>A WaitForSeconds object.</returns>
        public static WaitForSeconds GetWaitForSeconds(float seconds)
        {
            if (WaitForSeconds.TryGetValue(seconds, out var forSeconds)) return forSeconds;

            var waitForSeconds = new WaitForSeconds(seconds);
            WaitForSeconds.Add(seconds, waitForSeconds);
            return WaitForSeconds[seconds];
        }
        
        public static void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}

