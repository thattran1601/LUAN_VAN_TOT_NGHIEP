using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool IsOver =false;
    public bool IsWin;
    public GameObject gameOver;
    public GameObject Victory;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        IsOver = true;
        gameOver.SetActive(true);   
    }    
    public void victory()
    {
        IsWin = true;
        Victory.SetActive(true);
        SaveManager.instance.UnLockMap(GameData.MapInt + 1);
          
    }    
    public void ButtonRetry()
    {
       IsOver = false;
        gameOver.SetActive(false);
        SceneManager.LoadScene(
             SceneManager.GetActiveScene().buildIndex);
    }    
    public void ButtonHome()
    {
       SceneTransition.Instance.LoadSceneManager("Lobby");
    }    
}
