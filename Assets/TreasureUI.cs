using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreasureUI : MonoBehaviour
{
    public ItemData Treasure;
    public Image Icon;
    public TextMeshProUGUI TextName;
    public Button Button;
    public void setup(ItemData Treasures)
    {
        Treasure = Treasures;
        Icon.sprite = Treasures.Item;
        TextName.text = Treasures.Name;
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(OnclickButton);
    } 
    public void OnclickButton()
    {
        TreasureManager.instance.OnclickUseTreasure(Treasure);
    }    

}
