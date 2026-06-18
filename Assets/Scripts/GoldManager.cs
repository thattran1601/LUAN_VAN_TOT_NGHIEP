using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;
    public Image IconGold;
    public TextMeshProUGUI TextGold;
    public TextMeshProUGUI TextGoldPanel;
    public int CurrentGold;
    public int coinForSecond;
    public TextMeshProUGUI TextForSecond;
    public TextMeshProUGUI TextForSecondPanel;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(AddGoldPerSecond());
        UpdateGoldUI();
    }

    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    AddGold(100);
        //}    
    }
    public void AddGold(int gold)
    {
        CurrentGold += gold;
        UpdateGoldUI();
    }    
    public void UpdateGoldUI()
    {
        TextGold.text = CurrentGold.ToString();
        TextGoldPanel.text= CurrentGold.ToString();
        TextForSecond.text = coinForSecond.ToString() +"/s";
        TextForSecondPanel.text = coinForSecond.ToString() + "/s";


    }
    IEnumerator AddGoldPerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (GameManager.instance.IsOver)
                continue;

            if (GameManager.instance.IsWin)
                continue;

            if (UISetting.intance != null && UISetting.intance.isSetting)
                continue;

            CurrentGold += coinForSecond;
            UpdateGoldUI();
        }
    }

}
