using UnityEngine;
using UnityEngine.SceneManagement;

public class QuanLyMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayBMG(AudioManager.instance.MainMenuSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPlay()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);
        SceneTransition.Instance.LoadSceneManager("Lobby");
    }    
    public void ButtonQuit()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);
        Application.Quit();
    }    
}
