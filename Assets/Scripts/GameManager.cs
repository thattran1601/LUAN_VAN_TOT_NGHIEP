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
        int currenmap = GameData.MapInt;
        IsWin = true;
        Victory.SetActive(true);
        SaveManager.instance.UnLockMap(GameData.MapInt + 1);
        switch (currenmap)
        {
            case 1:
                SaveManager.instance.UnLockUnit(3);
                break; 
            case 2:
                SaveManager.instance.UnLockUnit(4);
                break;
            case 3:
                SaveManager.instance.UnLockUnit(5);
                break; 
            case 4:
                SaveManager.instance.UnLockUnit(6);
                break; 

        }
          
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
