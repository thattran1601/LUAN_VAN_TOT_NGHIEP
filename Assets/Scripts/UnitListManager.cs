using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitListManager : MonoBehaviour
{
    public static UnitListManager Instance;

    public GameObject PrelafUnit;
    public Transform content;
    public UnitData[] allunit;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (UnitOwnedManager.Instance != null)
            UnitOwnedManager.Instance.InitUnit();
        RefreshList();
    }
    private void Update()
    {
     
    }

    public void GenerateUnitList()
    {
        foreach (UnitData unit in allunit)
        {
            if(UnitOwnedManager.Instance.IsUnlocked(unit.Id))
            {
                GameObject obj = Instantiate(PrelafUnit, content);
                obj.GetComponent<UnitItemUI>().Setup(unit);
            }    
         
        }
    }

    public void RefreshList()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        GenerateUnitList();
    }
}