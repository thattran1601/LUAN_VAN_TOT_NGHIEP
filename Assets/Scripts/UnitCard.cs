using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitCard : MonoBehaviour
{
    public UnitData unitData;
    public Image icon;
    public TextMeshProUGUI nameText;
    public GameObject checkmask;
    public SelectUnitComfin manager;
    void Start()
    {
        manager = FindObjectOfType<SelectUnitComfin>();
        nameText.text = unitData.Name;
        icon.sprite = unitData.icon;
        bool check = manager.SelectUnit.Contains(unitData);
        checkmask.SetActive(check);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick()
    {
        bool IsSelected = manager.selectedunit(unitData);
        checkmask.SetActive(IsSelected);
    }    
}
