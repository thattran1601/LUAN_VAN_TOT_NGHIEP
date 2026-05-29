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
    public bool IsUnitUnlocked(int unitid)
    {
        if(unitid==1||unitid==2)
        {
            return true;
        }
        return PlayerPrefs.GetInt("Unit_" + unitid, 0) == 1;
    }    
    public void UnLockMap(int id)
    {
        int unlockmap = PlayerPrefs.GetInt("UnLockMap", 1);
        if(id>unlockmap)
        {
            PlayerPrefs.SetInt("UnLockMap", id);
            PlayerPrefs.Save();
            Debug.Log("Đã mở map: " + id);
        }    
    }    
    public int GetUnLockMap()
    {
        return PlayerPrefs.GetInt("UnLockMap", 1);
    }    
    public void ResetMap()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneTransition.Instance.LoadSceneManager("MainMenu");
        ButtonResetData.instance.ResetPanel.SetActive(false);
    }    
}
