using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyManager : MonoBehaviour
{
    public GameObject Battle;
    public GameObject Lobby;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayeGame()
    {
        Battle.SetActive(true);
        Lobby.SetActive(false);
    }    
    public void Back()
    {
        SceneTransition.Instance.LoadSceneManager("MainMenu");
    }    
    public void Unit()
    {
        SceneTransition.Instance.LoadSceneManager("Unit");
    }    
    public void Quit()
    {
        Battle.SetActive(false);
        Lobby.SetActive(true);
    }    
}
