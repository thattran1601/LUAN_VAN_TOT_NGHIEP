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
    public Slider Music;
    public Slider SFX;
    private void Awake()
    {
        intance = this;
    }
    void Start()
    {
        PanelSetting.SetActive(false);

        Music.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SFX.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        AudioManager.instance.SetMusicVolume(Music.value);
        AudioManager.instance.SetSFXVolume(SFX.value);

        Music.onValueChanged.AddListener(OnMusicChanged);
        SFX.onValueChanged.AddListener(OnSFXChanged);
    }

    void OnMusicChanged(float value)
    {
        AudioManager.instance.SetMusicVolume(value);
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }

    void OnSFXChanged(float value)
    {
        AudioManager.instance.SetSFXVolume(value);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
    void Update()

    {
        
    }
    public void Setting()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);


        isSetting = true;
        PanelSetting.SetActive(true);

    }
    public void Close()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);

        isSetting = false;
        PanelSetting.SetActive(false);
    }
    public void Quit()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);

        PanelSetting.SetActive(false);
        SceneTransition.Instance.LoadSceneManager("Lobby");
    }
    public void Restart()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);

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
