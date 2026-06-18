using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI Amount;
    private void Start()
    {
        
    }
    public void setEmpty()
    {
        icon.gameObject.SetActive(false);
        Amount.text = "";
    }    
    public void Setup(ItemData item,int amount)
    {


        icon.gameObject.SetActive(true);

        icon.sprite = item.Item;
            Amount.text = amount.ToString();
        
    
      
    }    
}
