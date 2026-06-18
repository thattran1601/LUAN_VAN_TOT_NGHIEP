using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CatleManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI TextLevel;
    public TextMeshProUGUI textLevelNext;
    public TextMeshProUGUI TextUpdate;
    public TextMeshProUGUI Arrow;
    public int Cost=30;
    private int level=1;
    private int levelnext;
    public ManaManager manaManager;


    public GameObject NotificationPanel;
    void Start()
    {
        panel.SetActive(false);
        TextLevel.text = "LV1" + "\n" + "Coin " + GoldManager.instance.coinForSecond.ToString() + "/s" +
            "\n"+ "Mana " + (manaManager.ManaForSeconds.ToString()) +"/s";
        textLevelNext.text="LV2" + "\n" + "Coin " + (GoldManager.instance.coinForSecond+2).ToString() + "/s" +
            "\n" +"Mana "+((manaManager.ManaForSeconds+1).ToString())+"/s";

        TextUpdate.text = "Chi phí nâng cấp : 30";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCatle()
    {
        
        Debug.Log(GoldManager.instance.CurrentGold);
        if (GoldManager.instance.CurrentGold < Cost)
        {
            Notification();

        }
        else 
        {
            level++;
            GoldManager.instance.coinForSecond += 2;
            GoldManager.instance.CurrentGold-=Cost;
            manaManager.ManaForSeconds += 1;
            Cost += 50;
            levelnext = level + 1;
            UpdateUI();

        }

    }    
    public void UpdateUI()
    {
        TextLevel.text = "LV" +level.ToString()+
    "\n" + "Coin " + GoldManager.instance.coinForSecond.ToString() + "/s" +
    "\n"+ "Mana " + (manaManager.ManaForSeconds.ToString()) + "/s";
        textLevelNext.text = "LV" +levelnext.ToString()+ "\n" + "Coin " + (GoldManager.instance.coinForSecond+2).ToString() + "/s" +
            "\n" + "Mana " + ((manaManager.ManaForSeconds + 1).ToString()) + "/s";
        TextUpdate.text = "Chi phí nâng cấp : " + Cost.ToString(); ;
    }    
    public void Notification()
    {
        NotificationPanel.SetActive(true);
    }   
    public void ButttonOke()
    {
        NotificationPanel.SetActive(false);
    }    
    public void OnMouseDown()
    {
        panel.SetActive(true);
    }    
    public void buttonClose()
    {
        panel.SetActive(false);
    }    
    

}
