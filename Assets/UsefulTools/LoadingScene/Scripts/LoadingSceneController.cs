using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UsefulTools.LoadingScene
{
    public class LoadingSceneController : MonoBehaviour
    {
        private static string sceneToLoad = "";
    
        [SerializeField]
        private Slider progressBar;
    
        private AsyncOperation loadingOperation;

        private void Awake()
        {
            Time.timeScale = 1f;
        }

        private void Start()
        {
            StartCoroutine(Load());
        }

        public static IEnumerator LoadScene([NotNull] string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(sceneName));
            }

            sceneToLoad = sceneName;
        
            FadeToBlack.ToBlack();

            yield return FadeToBlack.WaitForEndOfAnimation();
        
            SceneManager.LoadSceneAsync("Loading");
        }

        private IEnumerator Load()
        {
            FadeToBlack.FromBlack();

            yield return FadeToBlack.WaitForEndOfAnimation();
        
            loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
            loadingOperation.allowSceneActivation = false;
        
            while (!loadingOperation.isDone)
            {
                progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);

                if (loadingOperation.progress >= 0.9f)
                {
                    FadeToBlack.ToBlack();

                    yield return FadeToBlack.WaitForEndOfAnimation();
                
                    loadingOperation.allowSceneActivation = true;
                
                    FadeToBlack.FromBlack();
                    break;
                }

                yield return new WaitForEndOfFrame();
            }
        
            yield return null;
        }
    
    }
}
