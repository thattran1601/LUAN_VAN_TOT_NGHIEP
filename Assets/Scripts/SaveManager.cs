using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private void Awake()
    {
        instance = this;
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
}
