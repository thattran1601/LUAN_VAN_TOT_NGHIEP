using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool IsOver =false;
    public bool IsWin;
    public GameObject gameOver;
    public GameObject Victory;
    public ShowItemVictory itemVictory;
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
        MapData mapData = ItemMap.Instance.mapDatas[currenmap-1];
        List<RewardResult> rewards = ItemMap.Instance.AddItemWin(mapData);
        itemVictory.ShowItem(rewards,mapData);
        InventoryManager.Instance.LoadInventory();
        SaveGameManager.instance.LoadMap(mapData.IdMap+1);
        switch (currenmap)
        {
            case 1:
                SaveGameManager.instance.SaveUnit(2,true);
                //UnitListManager.Instance.RefreshList();
                //SaveGameManager.instance.LoadUnit();
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
