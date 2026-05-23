using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    public static UISetting intance;
    public GameObject PanelSetting;
    public bool isSetting;
    public Image FadeImage;
    public float FadeTime;
    private void Awake()
    {
        intance = this;
    }
    void Start()
    {
        PanelSetting.SetActive(false);
    }
    void Update()

    {
        
    }
    public void Setting()
    {
        isSetting = true;
        PanelSetting.SetActive(true);
    }    
    public void Close()
    {
        isSetting=false;
        PanelSetting.SetActive(false);
    }
    public void Quit()
    {
        PanelSetting.SetActive(false);
        SceneTransition.Instance.LoadSceneManager("Lobby");
    }
    public void Restart()
    {
        PanelSetting.SetActive(false);
        StartCoroutine(StartFade());
 
    }    
    IEnumerator StartFade()
    {
        yield return Fade(0, 1);
        FadeImage.raycastTarget = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  
    IEnumerator Fade(float from,float to)
    {
        float time = 0;
        Color color = FadeImage.color;
        while(time<FadeTime)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(from, to, time / FadeTime);
            FadeImage.color=color;
            yield return null;
        }
        color.a = to;
        FadeImage.color=color;
    }
}
