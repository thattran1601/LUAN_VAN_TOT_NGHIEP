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
    public TextMeshProUGUI TextCost;
    
    public int coin;
    public bool iscooldown;
    public void setup(UnitData data)
    {
        unitData = data;
        icon.sprite = data.icon;
        button.interactable = true;
        cooldown = data.Cooldown;
        TextCost.text = data.cost.ToString();
        coin=data.cost;

    }
    private void Update()
    {
        bool enoughGold = GoldManager.instance.CurrentGold >= coin;
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

        if (GoldManager.instance.CurrentGold>= coin)
        {
            GoldManager.instance.CurrentGold -= coin;

            GoldManager.instance.UpdateGoldUI();

            Vector3 pos = spawn.instance.spawnpoint.position;
            pos.z = 0f;

            Debug.Log("SpawnPoint: " + spawn.instance.spawnpoint.name);
            Debug.Log("SpawnPos: " + pos);

            GameObject unit = Instantiate(
                unitData.prelaf,
                pos,
                Quaternion.identity
            );
            unit.GetComponent<AI_Chuyen_Dong>().setup(unitData);
            UnitRuntimeStats stats = unit.GetComponent<UnitRuntimeStats>();
            if(stats!=null)
            {
                stats.setup(unitData);
            }    
            Debug.Log("UnitPos After Spawn: " + unit.transform.position);

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
