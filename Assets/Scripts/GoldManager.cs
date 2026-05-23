using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;
    public Image IconGold;
    public TextMeshProUGUI TextGold;
    public int CurrentGold;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        UpdateGoldUI();
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            AddGold(100);
        }    
    }
    public void AddGold(int gold)
    {
        CurrentGold += gold;
        UpdateGoldUI();
    }    
    public void UpdateGoldUI()
    {
        TextGold.text = CurrentGold.ToString();
    }    

}
