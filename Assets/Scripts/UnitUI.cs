using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public Image Lock;
    public UnitData UnitId;
    public Button button;
    void Start()
    {
        bool isUnick = SaveGameManager.instance.LoadUnit(UnitId.Id); 
        Lock.gameObject.SetActive(!isUnick);
        button.interactable = isUnick;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
