using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    public Image FadeImage;
    public float fadeTime;
    private void Start()
    {
        FadeImage.raycastTarget = false;
        
    }
    private void Awake()
    {
        Instance = this;
    }
    public void LoadSceneManager(string scenename)
    {
        StartCoroutine(LoadSence(scenename));
    }    
   public IEnumerator LoadSence(string sencename)
    {
        yield return Fade(0,1);
        SceneManager.LoadScene(sencename);
        FadeImage.raycastTarget=true;
    }
    public IEnumerator Fade(float from, float to)
    {
        float time = 0;
        Color color=FadeImage.color;
        while(time<fadeTime)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(from, to, time / fadeTime);
            FadeImage.color= color;
            yield return null;
        }
        color.a = to;
        FadeImage.color= color;
    }    
}
