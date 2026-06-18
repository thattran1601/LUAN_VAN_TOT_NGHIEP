using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void UnLockUnit(int id)
    {
        PlayerPrefs.SetInt("Unit_" + id, 1);
        PlayerPrefs.Save();

    }   
    public void Delete()
    {
        SaveGameManager.instance.DeleteAllSave();
        InventoryManager.Instance.LoadInventory();
        SceneTransition.Instance.LoadSceneManager("MainMenu");
    }    
    public bool IsUnitUnlocked(int unitid)
    {
        if(unitid==0||unitid==1)
        {
            return true;
        }
        return PlayerPrefs.GetInt("Unit_" + unitid, 0) == 1;
    }    
      
   
}
