using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUnitSlots : MonoBehaviour
{
    public UnitData unitData;
    public Image icon;
    public Image gameObjectCooldown;
    public int cooldown;
    public TextMeshProUGUI TextCooldown;
    public Button button;
    
    public int coin;
    public bool iscooldown;
    public void setup(UnitData data)
    {
        unitData = data;
        icon.sprite = data.icon;
        button.interactable = true;
        cooldown = data.Cooldown;
        coin=data.cost;

    }
    private void Update()
    {
        bool enoughGold = spawn.instance.Gold_current >= coin;
        if(enoughGold==true && iscooldown==false)
        {
            icon.color=Color.white;
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
            icon.color = new Color(0.4f, 0.4f, 0.4f, 0.1f);
        }
    }
    public void SpawnButton()
    {
        if (unitData == null)
            return;
       
        if (spawn.instance.Gold_current>=coin)
        {
            spawn.instance.Gold_current -= coin;
            Debug.Log(spawn.instance.Gold_current);
            GoldManager.instance.CurrentGold = spawn.instance.Gold_current;
            GoldManager.instance.UpdateGoldUI();
            Instantiate(unitData.prelaf, 
                spawn.instance.spawnpoint.position,
                Quaternion.identity);
            StartCoroutine(CooldownRoutine());
           
        }    
        
    }
    IEnumerator CooldownRoutine()
    {
        iscooldown = true;
        float time = cooldown;
        gameObjectCooldown.gameObject.SetActive(true);

        while(time>0)
        {
            gameObjectCooldown.fillAmount =Mathf.Clamp01( time / cooldown);
            TextCooldown.text=Mathf.Ceil(time).ToString();
            time -= Time.deltaTime;
            yield return null;

        }
        TextCooldown.text = "";
        gameObjectCooldown.gameObject.SetActive(false);
        iscooldown = false;
        gameObjectCooldown.fillAmount = 0;
        
    }    
}
