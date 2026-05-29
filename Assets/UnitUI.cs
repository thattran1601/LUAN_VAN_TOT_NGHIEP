using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public Image Lock;
    public int UnitId;
    public Button button;
    void Start()
    {
        bool isUnick = SaveManager.instance.IsUnitUnlocked(UnitId); 
        Lock.gameObject.SetActive(!isUnick);
        button.interactable = isUnick;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
