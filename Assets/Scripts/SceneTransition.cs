using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;

    public Image fadeImage;
    public float fadeTime = 0.5f;

    private bool isLoading;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void LoadSceneManager(string sceneName)
    {
        if (isLoading) return;

        if (!gameObject.activeInHierarchy)
        {
            SceneManager.LoadScene(sceneName);
            return;
        }

        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        isLoading = true;

        yield return Fade(1);

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        if (fadeImage == null)
        {
            Debug.LogWarning("SceneTransition chưa gán Fade Image");
            yield break;
        }

        Color color = fadeImage.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < fadeTime)
        {
            if (fadeImage == null)
                yield break;

            time += Time.deltaTime;

            color.a = Mathf.Lerp(startAlpha, targetAlpha, time / fadeTime);
            fadeImage.color = color;

            yield return null;
        }

        color.a = targetAlpha;
        fadeImage.color = color;
    }
}