using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GameObject Battle;
    public GameObject Lobby;
    private void Start()
    {
       
    }

    private void PlayClickSound()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);
        }
    }

    private void LoadSceneSafe(string sceneName)
    {
        if (SceneTransition.Instance != null)
        {
            SceneTransition.Instance.LoadSceneManager(sceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void PlayeGame()
    {
        PlayClickSound();

        Battle.SetActive(true);
        Lobby.SetActive(false);
    }

    public void UpgradeSolider()
    {
        PlayClickSound();
        LoadSceneSafe("Upgrade");
    }

    public void Back()
    {
        PlayClickSound();
        LoadSceneSafe("MainMenu");
    }

    public void Unit()
    {
        PlayClickSound();
        LoadSceneSafe("Unit");
    }

    public void Quit()
    {
        PlayClickSound();

        Battle.SetActive(false);
        Lobby.SetActive(true);
    }
}